using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Mapper
{
    public static class Mapper
    {
        public static dynamic Map<T>(this object src)
            where T : class
        {
            switch (typeof(T).Name)
            {
                case "BusinessItemViewModel":
                    var obj = new BusinessItem();
                    obj.CopyPropertiesFrom(src);

                    // Make Entity Include for BusinessItem
                    return new BusinessItemViewModel
                    {
                        Id = obj.Id,
                        Name = obj.Item.Name,
                        Description = obj.Item.Description,
                        //Group = obj.Item.Group.Name,
                        Quantity = obj.Quantity,
                        PriceCost = obj.Prices.Single(dm => dm.Type == PriceType.Cost).Amount,
                        PriceTarget = obj.Prices.Single(dm => dm.Type == PriceType.Target).Amount,
                        PricePremium = obj.Prices.Single(dm => dm.Type == PriceType.Premium).Amount,
                        DateOfProduction = obj.DateOfProduction,
                        DateOfLastSoldItem = obj.DateOfLastSold
                    };

                default:
                    throw new Exception("Cannot map to this object");
            }
        }
    }
}
