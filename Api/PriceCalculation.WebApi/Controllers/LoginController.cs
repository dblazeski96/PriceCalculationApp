using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PriceCalculation.Models.View.Output;
using Newtonsoft.Json;

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
        public HttpResponseMessage Login(string email, string password)
        {
            System.Threading.Thread.Sleep(2000);

            if (email.ToLower() == "demo@")
            {
                if (password.ToLower() == "demopass")
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    var error = new Error
                    {
                        Type = "password",
                        Message = "You entered a wrong password"
                    };

                    return Request.CreateErrorResponse(HttpStatusCode.Forbidden, JsonConvert.SerializeObject(error));
                }
            }
            else
            {
                var error = new Error
                {
                    Type = "email",
                    Message = "Email address is not registered"
                };

                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, JsonConvert.SerializeObject(error)); 
            }
        }

    }
}
