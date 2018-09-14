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
        public HttpResponseMessage GetAllBusinessItems()
        {
            var businessItemsResult = _searchService.GetAll();
            if (businessItemsResult.Success == false)
            {
                throw businessItemsResult.ex;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            var businessItems = businessItemsResult.Items;
            var responseContent = new StringContent(JsonConvert.SerializeObject(businessItems));

            response.Content = responseContent;

            return response;
        }

        [HttpGet]
        [Route("getbusinessitem/{id:int}")]
        public HttpResponseMessage GetBusinessItem([FromUri] int id)
        {
            var getBusinessItemResult = _searchService.Get(id);
            if (getBusinessItemResult.Success == false)
            {
                throw getBusinessItemResult.ex;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            var businessItem = getBusinessItemResult.Item;
            var responseContent = new StringContent(JsonConvert.SerializeObject(businessItem));

            response.Content = responseContent;

            return response;
        }

        [HttpPost]
        [Route("changebusinessitem")]
        public HttpResponseMessage ChangeBusinessItem([FromBody]BusinessItem businessItem)
        {
            var changeBusinessItemResult = _searchService.Change(businessItem);
            if (changeBusinessItemResult.Success == false)
            {
                throw changeBusinessItemResult.ex;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpPost]
        [Route("changemultiplebusinessitems")]
        public HttpResponseMessage ChangePropertyOfMultipleItems([FromUri]string property, [FromUri]string value, [FromBody]List<int> items)
        {
            var CPoMIResult = _searchService.ChangePropertyOfMultipleItems(property, value, items);
            if(CPoMIResult.Success == false)
            {
                throw CPoMIResult.ex;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(items[1].ToString());

            return response;
        }
    }
}
