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

namespace PriceCalculation.Service
{
    public class SearchService : BaseService, ISearchService
    {
        private readonly IPriceCalculationUoW _priceCalculationUoW;

        public SearchService(IPriceCalculationUoW priceCalculationUoW)
        {
            _priceCalculationUoW = priceCalculationUoW;
        }

        public ServiceResult<TViewModel> ChangePropertyOfMultipleItems<TViewModel, T>(string property, string value, List<int> items) 
            where T : class
            where TViewModel : class
        {

            try
            {
                foreach (var itemId in items)
                {
                    var repository = DetermineRepository<T>(this);

                    var item = repository.GetType().GetMethod("Get").Invoke(repository, new object[] { itemId });
                    item.GetType().GetProperty(property).SetValue(item, int.Parse(value));

                    repository.GetType().GetMethod("Change").Invoke(repository, new object[] { item });
                }

                return new ServiceResult<TViewModel>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TViewModel>
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
