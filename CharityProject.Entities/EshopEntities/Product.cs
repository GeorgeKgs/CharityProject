using CharityProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.DomainClasses
{
    public enum Size
    {
        XS,S,M,L,XL,XXL
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Size Size { get; set; }
        public string ImageUrl { get; set; }

    }
}
