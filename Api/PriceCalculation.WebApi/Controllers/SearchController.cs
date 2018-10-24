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
using System.Web.Http.Cors;

namespace PriceCalculation.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        //
        //
        //
        // NEED TO REFACTOR TO USE LESS ACTIONS OR SERVICES
        //
        //
        //

        //
        // Business Item
        //
        [HttpPost]
        [Route("CreateBusinessItem")]
        public HttpResponseMessage CreateBusinessItem([FromBody]BusinessItemIModel businessItem)
        {
            var serviceResult = _searchService.CreateBusinessItem(businessItem);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpPost]
        [Route("ChangeBusinessItem")]
        public HttpResponseMessage ChangeBusinessItem([FromBody]BusinessItemIModel businessItem)
        {
            var serviceResult = _searchService.ChangeBusinessItem(businessItem);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpPost]
        [Route("RemoveBusinessItem/{id:int}")]
        public HttpResponseMessage RemoveBusinessItem([FromUri]int id)
        {
            var serviceResult = _searchService.RemoveBusinessItem(id);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpGet]
        [Route("GetBusinessItem/{id:int}")]
        public HttpResponseMessage GetBusinessItem([FromUri]int id)
        {
            var serviceResult = _searchService.GetBusinessItem(id);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(serviceResult.Item));

            return response;
        }

        [HttpGet]
        [Route("GetAllBusinessItems")]
        public HttpResponseMessage GetAllBusinessItems([FromUri]string property, [FromUri]string searchCriteria)
        {
            var serviceResult = _searchService.GetAllBusinessItems(property, searchCriteria);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(serviceResult.Items));

            return response;
        }

        [HttpOptions]
        public HttpResponseMessage ChangePropertyOfMultipleBusinessItems()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("ChangePropertyOfMultipleBusinessItems")]
        public HttpResponseMessage ChangePropertyOfMultipleBusinessItems([FromUri]string property, [FromUri]string value, [FromBody]List<int> items)
        {
            var serviceResult = _searchService.ChangePropertyOfMultipleBusinessItems(property, value, items);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        //
        // Business Entity
        //
        [HttpPost]
        [Route("CreateBusinessEntity")]
        public HttpResponseMessage CreateBusinessEntity([FromBody]BusinessEntityIModel businessEntity)
        {
            var serviceResult = _searchService.CreateBusinessEntity(businessEntity);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpPost]
        [Route("ChangeBusinessEntity")]
        public HttpResponseMessage ChangeBusinessEntity([FromBody]BusinessEntityIModel businessEntity)
        {
            var serviceResult = _searchService.ChangeBusinessEntity(businessEntity);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpPost]
        [Route("RemoveBusinessEntity/{id:int}")]
        public HttpResponseMessage RemoveBusinessEntity(int id)
        {
            var serviceResult = _searchService.RemoveBusinessEntity(id);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpGet]
        [Route("GetBusinessEntity/{id:int}")]
        public HttpResponseMessage GetBusinessEntity(int id)
        {
            var serviceResult = _searchService.GetBusinessEntity(id);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(serviceResult.Item));

            return response;
        }

        [HttpGet]
        [Route("GetAllBusinessEntities")]
        public HttpResponseMessage GetAllBusinessEntities([FromUri]string property, [FromUri]string searchCriteria)
        {
            var serviceResult = _searchService.GetAllBusinessEntities(property, searchCriteria);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(serviceResult.Items));

            return response;
        }

        [HttpPost]
        [Route("ChangePropertyOfMultipleBusinessEntities")]
        public HttpResponseMessage ChangePropertyOfMultipleBusinessEntites([FromUri]string property, [FromUri]string value, [FromBody]List<int> items)
        {
            var serviceResult = _searchService.ChangePropertyOfMultipleBusinessEntities(property, value, items);
            if (!serviceResult.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, serviceResult.ex.Message, serviceResult.ex);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

    }
}
