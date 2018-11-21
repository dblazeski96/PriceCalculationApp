using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PriceCalculation.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        public LoginController()
        {
        }

        [HttpGet]
        [Route("RequestLogin")]
        public HttpResponseMessage Login()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            System.Threading.Thread.Sleep(2000);

            return response;
        }

    }
}
