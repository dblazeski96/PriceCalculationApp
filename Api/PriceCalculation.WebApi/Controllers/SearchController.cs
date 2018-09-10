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
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        
        [HttpGet]
        [Route("getallbusinessitems")]
        public async Task<HttpResponseMessage> GetAllBusinessItems()
        {
            var businessItemsResult = await _searchService.GetAll();

            if (businessItemsResult.Success)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK);

                var businessItems = businessItemsResult.Items;
                var responseContent = JsonConvert.SerializeObject(businessItems);

                response.Content = new StringContent(responseContent);

                return response;
            }
            else
            {
                var exception = businessItemsResult.ex;

                var response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message, exception);

                return response;
            }
        }
    }
}
