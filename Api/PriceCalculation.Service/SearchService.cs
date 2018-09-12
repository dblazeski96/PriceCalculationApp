using PriceCalculation.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using PriceCalculation.Mapper;

namespace PriceCalculation.Service
{
    public class SearchService : ISearchService
    {
        private readonly ISearchUoW _searchUoW;

        public SearchService(ISearchUoW searchUoW)
        {
            _searchUoW = searchUoW;
        }

        public ServiceResult<BusinessItemViewModel> Create(BusinessItem item)
        {
            try
            {
                _searchUoW._businessItemRepository.Create(item);
                _searchUoW.Commit();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        public ServiceResult<BusinessItemViewModel> Change(BusinessItem item)
        {
            try
            {
                _searchUoW._businessItemRepository.Change(item);
                _searchUoW.Commit();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        public ServiceResult<BusinessItemViewModel> Remove(int id)
        {
            try
            {
                _searchUoW._businessItemRepository.Remove(id);
                _searchUoW.Commit();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        public ServiceResult<BusinessItemViewModel> Get(int id)
        {
            try
            {
                var item = _searchUoW._businessItemRepository.Get(id);
                var itemViewModel = item.MapToViewModel();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true,
                    Item = itemViewModel
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        public ServiceResult<BusinessItemViewModel> GetAll()
        {
            try
            {
                var items = _searchUoW._businessItemRepository.GetAll();
                var itemsViewModels = new List<BusinessItemViewModel>();

                foreach(var item in items)
                {
                    itemsViewModels.Add(item.MapToViewModel());
                }

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true,
                    Items = itemsViewModels
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemViewModel>
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
