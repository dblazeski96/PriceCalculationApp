using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PriceCalculation.Service;
using PriceCalculation.ViewModels;
using PriceCalculation.Data.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PriceCalculation.WebApi.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private IBusinessItemService _businessItemService;
        public SearchController(IBusinessItemService businessItemService)
        {
            _businessItemService = businessItemService;
        }

        [HttpGet]
        [Route("getallbusinessitems")]
        public async Task<HttpResponseMessage> GetAllBusinessItems()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var businessItemsResponse = await _businessItemService.GetAll();
            var businessItems = businessItemsResponse.Items;

            var responseContent = JsonConvert.SerializeObject(businessItems);

            response.Content = new StringContent(responseContent);

            return response;
        }
    }
}
