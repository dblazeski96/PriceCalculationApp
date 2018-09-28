using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using System;
using System.Collections;
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
                case "BusinessItemOModel":
                    {
                        var objMain = new BusinessItem();
                        objMain.CopyPropertiesFrom(src);

                        var mapObjMain = new BusinessItemOModel();

                        mapObjMain.Id = objMain.Id;
                        mapObjMain.Name = objMain.Item.Name;
                        mapObjMain.Description = objMain.Item.Description;
                        mapObjMain.Quantity = objMain.Quantity;
                        mapObjMain.PriceCost = objMain.Prices.Single(p => p.Type == PriceType.Cost).Amount;
                        mapObjMain.PriceTarget = objMain.Prices.Single(p => p.Type == PriceType.Target).Amount;
                        mapObjMain.PricePremium = objMain.Prices.Single(p => p.Type == PriceType.Premium).Amount;
                        mapObjMain.DateOfProduction = objMain.DateOfProduction;
                        mapObjMain.DateOfLastSoldItem = objMain.DateOfLastSold;

                        return mapObjMain;
                    }

                case "BusinessEntityOModel":
                    {
                        var objMain = new BusinessEntity();
                        objMain.CopyPropertiesFrom(src);

                        var mapObjMain = new BusinessEntityOModel();

                        mapObjMain.Id = objMain.Id;
                        mapObjMain.Name = objMain.Name;
                        mapObjMain.Type = objMain.Type.ToString();
                        mapObjMain.Currency = objMain.Currency.ToString();

                        return mapObjMain;
                    }

                default:
                    throw new Exception($"No implementation to map ${typeof(T).Name} model!");
            }
        }
    }
}
