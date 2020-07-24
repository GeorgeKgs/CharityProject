using CharityProject.Entities.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.CartEntities
{
    public class ProductVm
    {
        public int Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public ProductVm()
        {
            Products = new List<Product>();
        }
    }
}
