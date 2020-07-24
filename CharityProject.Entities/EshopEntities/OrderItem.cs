using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.EshopEntities
{
    public class OrderItem  
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
