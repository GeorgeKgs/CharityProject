using CharityProject.Database;
using CharityProject.Entities.CartEntities;
using CharityProject.Entities.EshopEntities;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CharityProject.Controllers
{
    public class EShopController : Controller
    {
        private CharityDBContext _dbContext;



        //Constructor
        public EShopController(CharityDBContext context)
        {
            _dbContext = context;
        }



        // GET: EShop
        public async Task<ActionResult> Index(string NumberOfItems)
        {
            ViewBag.NumberOfItems =  new List<string>{"3","6","9","12","24"};

            var model = new ProductVm();


            if (NumberOfItems == "" || NumberOfItems == "All" || NumberOfItems == null)
            {
                model.Products = await _dbContext.Products.ToListAsync();
            }
            else
            {
                model.Products = await _dbContext.Products.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();

            }






                return View(model);
        }




        public ActionResult Cart()
        {
            var cart = CreateOrGetCart();

            return View(cart);
        }

        public async Task<ActionResult> Add(int productId)
        {
           
            var product =await  _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

            var cart = CreateOrGetCart();
            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
               
            }
            else
            {
                cart.CartItems.Add(new CartItem()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = (int)product.Price,
                    Quantity = 1
                });
               
            }

            SaveCart(cart);
            TempData["AddMessage"] = "You successfully added an item to your Cart!";
            return RedirectToAction("Cart", "EShop");
        }

        public async Task<ActionResult> Delete(int productId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

            var cart = CreateOrGetCart();
            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == product.Id);

            if (existingItem != null)
            {
                cart.CartItems.Remove(existingItem);
            }

            SaveCart(cart);

            return RedirectToAction("Cart", "EShop");
        }


        public async Task<ActionResult> Checkout()
        {
            var cart = CreateOrGetCart();

            if (cart.CartItems.Any())
            {
                // Flat rate shipping
                int shipping = 0 ;

                // Flat rate tax 10%
                var taxRate = 0;

                var subtotal = cart.CartItems.Sum(x => x.Price * x.Quantity);
                var tax = Convert.ToInt32((subtotal + shipping) * taxRate);
                var total = subtotal + shipping + tax;

                // Create an Order object to store info about the shopping cart
                var order = new Entities.EshopEntities.Order()
                {
                    OrderDate = DateTime.UtcNow,
                    Subtotal = subtotal,
                    Shipping = shipping,
                    Tax = tax,
                    Total = total,
                    OrderItems = cart.CartItems.Select(x => new OrderItem()
                    {
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = x.Quantity
                    }).ToList()
                };
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();



                // Get PayPal API Context using configuration from web.config
                var apiContext = GetApiContext();

                // Create a new payment object
                var payment = new Payment
                {
                    
                    intent = "sale",
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            description = $"AKK Charity Shopping Cart Purchase",
                            amount = new Amount
                            {
                                currency = "EUR",
                                total = (order.Total/1M).ToString(), // PayPal expects string amounts, eg. "20.00",
                                details = new Details()
                                {
                                    subtotal = (order.Subtotal/1M).ToString(),
                                    shipping = (order.Shipping/1M).ToString(),
                                    tax = (order.Tax/1M).ToString()
                                }
                            },
                            item_list = new ItemList()
                            {
                                items =
                                    order.OrderItems.Select(x => new Item()
                                    {
                                        description = x.Name,
                                        currency = "EUR",
                                        quantity = x.Quantity.ToString(),
                                        price = (x.Price/1M).ToString(), // PayPal expects string amounts, eg. "20.00"
                                    }).ToList()
                            }
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = Url.Action("Return", "Eshop", null, Request.Url.Scheme),
                        cancel_url = Url.Action("Cancel", "Eshop", null, Request.Url.Scheme)
                    }
                };

                // Send the payment to PayPal
                var createdPayment = payment.Create(apiContext);

                // Save a reference to the paypal payment
                order.PayPalReference = createdPayment.id;
                await _dbContext.SaveChangesAsync();

                // Find the Approval URL to send our user to
                var approvalUrl =
                    createdPayment.links.FirstOrDefault(
                        x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

                // Send the user to PayPal to approve the payment
                return Redirect(approvalUrl.href);
            }





            return RedirectToAction("Cart");
        }




        public async Task<ActionResult> Return(string payerId, string paymentId)
        {
            // Fetch the existing order
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.PayPalReference == paymentId);

            // Get PayPal API Context using configuration from web.config
            var apiContext = GetApiContext();

            // Set the payer for the payment
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            // Identify the payment to execute
            var payment = new Payment()
            {
                id = paymentId
            };

            // Execute the Payment
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            ClearCart();

            return RedirectToAction("Thankyou");
        }



        public ActionResult Cancel()
        {
            return View();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        private Cart CreateOrGetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                SaveCart(cart);
            }

            return cart;
        }

        private void ClearCart()
        {
            var cart = new Cart();
            SaveCart(cart);
        }

        private void SaveCart(Cart cart)
        {
            Session["Cart"] = cart;
        }

        private APIContext GetApiContext()
        {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);
            return apiContext;
        }
    }
}