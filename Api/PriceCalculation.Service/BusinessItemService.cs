using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using PriceCalculation.Mapper;

namespace PriceCalculation.Service
{
    public class BusinessItemService : BaseService, IBusinessItemService
    {
        public BusinessItemService(IBusinessItemRepository businessItemRepository) : base(businessItemRepository)
        {
        }

        public async Task<ServiceResult<BusinessItemViewModel>> Create(BusinessItem item)
        {
            try
            {
                _businessItemRepository.Create(item);
                await _businessItemRepository.Commit();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true
                };
            }
            catch(Exception ex)
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
                await _businessItemRepository.Change(item);
                await _businessItemRepository.Commit();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true
                };
            }
            catch(Exception ex)
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
                await _businessItemRepository.Remove(id);
                await _businessItemRepository.Commit();

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
                var businessItem = await _businessItemRepository.Get(id);
                var businessItemViewModel = businessItem.Map();

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true,
                    Item = businessItemViewModel
                };
            }
            catch(Exception ex)
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
                var businessItems = await _businessItemRepository.GetAll();
                var businessItemsViewModel = new List<BusinessItemViewModel>();

                foreach(var item in businessItems)
                {
                    businessItemsViewModel.Add(
                        item.Map()
                    );
                }

                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = true,
                    Items = businessItemsViewModel
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<BusinessItemViewModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
    }
}
