using PriceCalculation.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using PriceCalculation.Mapper;
using System.Collections;
using PriceCalculation.Service;
using System.Reflection;
using PriceCalculation.Data.Repository;

namespace PriceCalculation.Service
{
    public class SearchService : BaseService, ISearchService
    {
        private readonly IPriceCalculationUoW _priceCalculationUoW;

        public SearchService(IPriceCalculationUoW priceCalculationUoW)
        {
            _priceCalculationUoW = priceCalculationUoW;
        }

        public ServiceResult<TOutput> ChangePropertyOfMultipleItems<TOutput>(string property, string value, IList<int> items)
            where TOutput : class
        {
            try
            {
                var serviceUoWs = ServiceHelper.GetServiceUoWs(this);
                var dataTypeModel = ServiceHelper.GetDataModelType<TOutput>();
                var repository = ServiceHelper.DetermineRepository(dataTypeModel, serviceUoWs);

                foreach (var itemId in items)
                {
                    var item = repository.GetType().GetMethod("Get").Invoke(repository, new object[] { itemId });

                    var itemProperty = item.GetType().GetProperty(property);
                    itemProperty.SetValue(item, Convert.ChangeType(value, itemProperty.PropertyType));

                    repository.GetType().GetMethod("Change").Invoke(repository, new object[] { item });
                }

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
