using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.DomainClasses
{
    public class Partner
    {
        public int PartnerId { get; set; }

        [Display(Name="Partner")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public Partner()
        {
            Donations = new HashSet<Donation>();
        }
    }
}
