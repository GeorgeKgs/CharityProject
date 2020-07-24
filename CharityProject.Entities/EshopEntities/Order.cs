using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.EshopEntities
{
    public class Order  
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public int Tax { get; set; }
        public int Subtotal { get; set; }
        public int Shipping { get; set; }
        public string PayPalReference { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
