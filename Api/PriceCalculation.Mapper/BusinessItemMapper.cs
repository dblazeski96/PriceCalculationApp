using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.ViewModels;
using PriceCalculation.Data.Models;

namespace PriceCalculation.Mapper
{
    public static class BusinessItemMapper
    {
        public static BusinessItemViewModel MapToViewModel(this BusinessItem dataModel)
        {
            return new BusinessItemViewModel
            {
                Id = dataModel.Id,
                Name = dataModel.Item.Name,
                Description = dataModel.Item.Description,
                Group = dataModel.Item.Group.Name,
                Quantity = dataModel.Quantity,
                PriceCost = dataModel.Prices.Single(dm => dm.Type == PriceType.Cost).Amount,
                PriceTarget = dataModel.Prices.Single(dm => dm.Type == PriceType.Target).Amount,
                PricePremium = dataModel.Prices.Single(dm => dm.Type == PriceType.Premium).Amount,
                DateOfProduction = dataModel.DateOfProduction,
                DateOfLastSoldItem = dataModel.DateOfLastSold
            };
        }
    }
}
