using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.DomainClasses
{
    public class Donation
    {
        public int DonationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Goal")]
        public decimal Price { get; set; }


        public int PlanId { get; set; }     
        public virtual Plan Plan { get; set; }

        public int PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
