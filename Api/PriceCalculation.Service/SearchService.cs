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

        public async Task<ServiceResult<BusinessItemViewModel>> Create(BusinessItem item)
        {
            try
            {
                _searchUoW._businessItemRepository.Create(item);
                await _searchUoW.Commit();

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

        public async Task<ServiceResult<BusinessItemViewModel>> Change(BusinessItem item)
        {
            try
            {
                await _searchUoW._businessItemRepository.Change(item);
                await _searchUoW.Commit();

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

        public async Task<ServiceResult<BusinessItemViewModel>> Remove(int id)
        {
            try
            {
                await _searchUoW._businessItemRepository.Remove(id);
                await _searchUoW.Commit();

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

        public async Task<ServiceResult<BusinessItemViewModel>> Get(int id)
        {
            try
            {
                var item = await _searchUoW._businessItemRepository.Get(id);
                var itemViewModel = item.Map();

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

        public async Task<ServiceResult<BusinessItemViewModel>> GetAll()
        {
            try
            {
                var items = await _searchUoW._businessItemRepository.GetAll();
                var itemsViewModels = new List<BusinessItemViewModel>();

                foreach(var item in items)
                {
                    itemsViewModels.Add(item.Map());
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
