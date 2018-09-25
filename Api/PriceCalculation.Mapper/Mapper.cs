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
        public static T Map<T>(this object src)
            where T : class
        {
            switch (typeof(T).Name)
            {
                case "BusinessItemViewModel":
                    var objMain = new BusinessItem();
                    objMain.CopyPropertiesFrom(src);

                    var mapObjMain = (T)Activator.CreateInstance(typeof(T));
                    var mapObjMainType = mapObjMain.GetType();

                    mapObjMainType.GetProperty("Id").SetValue(mapObjMain, objMain.Id);
                    mapObjMainType.GetProperty("Name").SetValue(mapObjMain, objMain.Item.Name);
                    mapObjMainType.GetProperty("Description").SetValue(mapObjMain, objMain.Item.Description);
                    mapObjMainType.GetProperty("Quantity").SetValue(mapObjMain, objMain.Quantity);
                    mapObjMainType.GetProperty("PriceCost").SetValue(mapObjMain, objMain.Prices.Single(dm => dm.Type == PriceType.Cost).Amount);
                    mapObjMainType.GetProperty("PriceTarget").SetValue(mapObjMain, objMain.Prices.Single(dm => dm.Type == PriceType.Target).Amount);
                    mapObjMainType.GetProperty("PricePremium").SetValue(mapObjMain, objMain.Prices.Single(dm => dm.Type == PriceType.Premium).Amount);
                    mapObjMainType.GetProperty("DateOfProduction").SetValue(mapObjMain, objMain.DateOfProduction);
                    mapObjMainType.GetProperty("DateOfLastSoldItem").SetValue(mapObjMain, objMain.DateOfLastSold);

                    return mapObjMain;

                default:
                    throw new Exception("Cannot map to this object");
            }
        }
    }
}
