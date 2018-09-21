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
                //var allItemsResult = Get<T>(1);

                //var allItemsElementType = allItems.GetType().GetGenericArguments()[0];
                //var allItemsType = typeof(List<>).MakeGenericType(allItemsElementType);

                //var filteredItems = (IList)Activator.CreateInstance(allItemsType);

                //foreach (var item in items)
                //{
                //    filteredItems.Add(allItems.Single(i => i.Id == item).MapToViewModel());
                //}

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
