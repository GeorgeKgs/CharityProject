using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject.Entities.DomainClasses
{
   public  class Subscription
   {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }

        public int PartnerId { get; set; }
        public virtual Partner Partner { get; set; }
   }
}
