using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PriceCalculation.Service;
using PriceCalculation.Models.View;

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

        [HttpPost]
        [Route("ChangePropertyOfMultipleBusinessItems")]
        public HttpResponseMessage ChangePropertyOfMultipleBusinessItems([FromUri]string property, [FromUri]string value, [FromBody]List<int> items)
        {
            var serviceResult = _searchService.ChangePropertyOfMultipleItems<BusinessItemOModel>(property, value, items);
            if (!(serviceResult.Success))
            {
                throw serviceResult.ex;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            response.Content = new StringContent(items[1].ToString());

            return response;
        }

        [HttpPost]
        [Route("CreateBusinessItem")]
        public HttpResponseMessage CreateBusinessItem([FromBody]BusinessItemIModel businessItem)
        {
            var serviceResult = _searchService.Create<BusinessItemIModel, BusinessItemOModel>(businessItem);
            if (!(serviceResult.Success))
            {
                throw serviceResult.ex;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("ChangeBusinessItem")]
        public HttpResponseMessage ChangeBusinessItem([FromBody]BusinessItemIModel businessItem)
        {
            var serviceResult = _searchService.Change<BusinessItemIModel, BusinessItemOModel>(businessItem);
            if (!(serviceResult.Success))
            {
                throw serviceResult.ex;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("RemoveBusinessItem/{id:int}")]
        public HttpResponseMessage RemoveBusinessItem([FromUri]int id)
        {
            var serviceResult = _searchService.Remove<BusinessItemOModel>(id);
            if (!(serviceResult.Success))
            {
                throw serviceResult.ex;
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("GetBusinessItem/{id:int}")]
        public HttpResponseMessage GetBusinessItem([FromUri]int id)
        {
            var serviceResult = _searchService.Get<BusinessItemOModel>(id);
            if (!(serviceResult.Success))
            {
                throw serviceResult.ex;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            var itemSerialized = JsonConvert.SerializeObject(serviceResult.Item);
            var responseContent = new StringContent(itemSerialized);

            response.Content = responseContent;

            return response;
        }

        [HttpGet]
        [Route("GetAllBusinessItems")]
        public HttpResponseMessage GetAllBusinessItems([FromUri]string property, [FromUri]string searchCriteria)
        {
            // Need to test a different Model
            var serviceResult = _searchService.GetAll<BusinessItemOModel>(property, searchCriteria);
            if (!(serviceResult.Success))
            {
                throw new WebException(serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            var businessItems = serviceResult.Items;
            var responseContent = new StringContent(JsonConvert.SerializeObject(businessItems));

            response.Content = responseContent;

            return response;
        }

        [HttpGet]
        [Route("GetAllBusinessEntities")]
        public HttpResponseMessage GetAllBusinessEntities()
        {
            var serviceResult = _searchService.GetAll<BusinessEntityOModel>(null, null);



            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
