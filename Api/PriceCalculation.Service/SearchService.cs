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
        private readonly ISearchUoW _searchUoW;

        public SearchService(ISearchUoW searchUoW)
        {
            _searchUoW = searchUoW;
        }

        public ServiceResult<TViewModel> ChangePropertyOfMultipleItems<TViewModel, T>(string property, string value, List<int> items) where TViewModel: class where T : class
        {
            try
            {
                var allItems = _searchUoW._businessItemRepository.GetAll();

                var allItemsElementType = allItems.GetType().GetGenericArguments()[0];
                var allItemsType = typeof(List<>).MakeGenericType(allItemsElementType);

                var filteredItems = (IList)Activator.CreateInstance(allItemsType);

                foreach (var item in items)
                {
                    filteredItems.Add(allItems.Single(i => i.Id == item).MapToViewModel());
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
            _searchUoW.Dispose();
        }
    }
}
