using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.DomainClasses
{
    public class Plan
    {
        public int PlanId { get; set; }

        [Display(Name = "Plan")]
        public string Category { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }


        public Plan()
        {
            Donations = new HashSet<Donation>();
        }

    }
}
