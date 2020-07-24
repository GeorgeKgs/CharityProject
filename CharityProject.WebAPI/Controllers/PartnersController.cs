using CharityProject.Database;
using CharityProject.Entities.DomainClasses;
using CharityProject.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace CharityProject.WebAPI.Controllers
{
    public class PartnersController : ApiController
    {
        
        private IGenericRepository<Partner> _repository;

        public PartnersController(IGenericRepository<Partner> repository)
        {
            _repository = repository;
        }


        //api/partners
        public async Task<IHttpActionResult> Get()
        {
            var result = await  _repository.GetAll();
            var data = result.Select(p => new
            {
                p.Name,
                p.Country,
                p.Address,
                p.Description,
                Donations = p.Donations.Select(d =>  new 
                    { 
                        d.Title,
                        d.Plan.Category,
                        d.Price, 
                        d.Description
                    }),
                Subscriptions = p.Subscriptions.Select(s => new 
                    { 
                        s.Title,
                        s.Plan.Category, 
                        s.Description 
                    })
            });
            return Ok(data);
        }
    }
}
