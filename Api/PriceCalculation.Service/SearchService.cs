using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Mapper;
using System.Collections;
using PriceCalculation.Service;
using System.Reflection;
using PriceCalculation.Data.Repository;
using PriceCalculation.Models.Base;
using PriceCalculation.Data.UnitOfWork;

namespace PriceCalculation.Service
{
    public class SearchService : BaseService, ISearchService
    {
        private readonly IPriceCalculationUoW _priceCalculationUoW;

        public SearchService(IPriceCalculationUoW priceCalculationUoW)
        {
            _priceCalculationUoW = priceCalculationUoW;
        }

        public ServiceResult<TOutput> ChangePropertyOfMultipleItems<TOutput>(string property, string value, IList<int> items) // Need to finish
            where TOutput : class, BaseViewModel
        {
            try
            {
                //var repository = ServiceHelper.DetermineRepository<TOutput>(this);

                //foreach (var itemId in items)
                //{
                //    var item = repository.Get(itemId);

                //    var itemProperty = item.GetType().GetProperty(property);
                //    itemProperty.SetValue(item, Convert.ChangeType(value, itemProperty.PropertyType));

                //    repository.Change(item);
                //}

                //ServiceHelper.SaveChanges(ServiceHelper.GetServiceUoWs(this));

                return new ServiceResult<TOutput>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        public void Dispose()
        {
            _priceCalculationUoW.Dispose();
        }
    }
}
