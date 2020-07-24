using CharityProject.Entities.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.ViewModels
{
    public class IndexVm
    {
        public int Id { get; set; }
        public virtual  ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }

        public IndexVm()
        {
            Donations = new List<Donation>();
            Subscriptions = new List<Subscription>();
            Partners = new List<Partner>();
            Plans = new List<Plan>();
        }

    }
}
