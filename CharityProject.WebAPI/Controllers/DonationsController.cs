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
    public class DonationsController : ApiController
    {

        private IGenericRepository<Donation> _repository;

        public DonationsController(IGenericRepository<Donation> repository)
        {
            _repository = repository;
        }

        //api/donations
        public async Task<IHttpActionResult> Get()
        {
            var result = await _repository.GetAll();
            var data = result.Select(p => new
            {
                p.Title,
                p.Price,
                p.Description,
                p.Partner.Name,
                p.Partner.Address,
                p.Partner.Country

            });
            return Ok(data);
        }
    }
}
