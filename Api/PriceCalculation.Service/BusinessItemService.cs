using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.Models;
using PriceCalculation.Service.Models;

namespace PriceCalculation.Service
{
    public class BusinessItemService : BaseService, IBusinessItemService
    {
        public Task<ServiceResult<BusinessItemViewModel>> Create(BusinessItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<BusinessItemViewModel>> Change(BusinessItem item)
        {
            try
            {
                await BusinessItemRepository.Change(item);

                await BusinessItemRepository.Save();

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

        public Task<ServiceResult<BusinessItemViewModel>> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<BusinessItemViewModel>> Get(int id)
        {
            try
            {
                var businessItem = await BusinessItemRepository.Get(id);
                var businessItemViewModel = new BusinessItemViewModel
                {
                    Id = businessItem.Id,
                    Name = businessItem.Item.Name,
                    Description = businessItem.Item.Description,
                    Group = businessItem.Item.Group.Name,
                    Quantity = businessItem.Quantity,
                    PriceCost = businessItem.Prices.Where(p => p.Type == PriceType.Cost).FirstOrDefault().Amount,
                    PriceTarget = businessItem.Prices.Where(p => p.Type == PriceType.Target).FirstOrDefault().Amount,
                    PricePremium = businessItem.Prices.Where(p => p.Type == PriceType.Premium).FirstOrDefault().Amount,
                    DateOfProduction = businessItem.DateOfProduction,
                    DateOfLastSoldItem = businessItem.DateOfLastSold
                };

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

        public Task<ServiceResult<BusinessItemViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
