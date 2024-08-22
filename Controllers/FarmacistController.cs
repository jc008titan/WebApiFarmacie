using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class FarmacistController : ApiController
    {

        private FarmacistRepository farmacistRepository;

        public FarmacistController()
        {
            this.farmacistRepository = new FarmacistRepository();
        }
        public Farmacist[] Get()
        {
            return farmacistRepository.GetAllFarmacisti();
        }

        public HttpResponseMessage Post(Farmacist farmacist)
        {
            this.farmacistRepository.SaveFarmacist(farmacist);

            var response = Request.CreateResponse<Farmacist>(System.Net.HttpStatusCode.Created, farmacist);

            return response;
        }
    }
}
