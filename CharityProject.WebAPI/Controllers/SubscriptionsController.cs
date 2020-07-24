using CharityProject.Entities.DomainClasses;
using CharityProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CharityProject.WebAPI.Controllers
{
    public class SubscriptionsController : ApiController
    {

        private IGenericRepository<Subscription> _repository;

        public SubscriptionsController(IGenericRepository<Subscription> repository)
        {
            _repository = repository;
        }


        //api/subscriptions
        public async Task<IHttpActionResult> Get()
        {
            var result = await _repository.GetAll();
            var data = result.Select(s => new
            {
                s.Title,
                s.Plan.Category,
                s.Description,
                s.Partner.Name,
                s.Partner.Address,
                s.Partner.Country

            });
            return Ok(data);
        }
    }
}
