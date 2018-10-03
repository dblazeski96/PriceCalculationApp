using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Mapper
{
    public static class Mapper
    {
        public static dynamic Map(this object src, Type mapModel)
        {
            switch (mapModel.Name)
            {
                case "BusinessItemOModel":
                    {
                        var srcObj = new BusinessItem();
                        srcObj.CopyPropertiesFrom(src);

                        var mapObj = new BusinessItemOModel();

                        mapObj.Id = srcObj.Id;
                        //mapObj.Name = srcObj.Item.Name;
                        //mapObj.Description = srcObj.Item.Description;
                        mapObj.Quantity = srcObj.Quantity;
                        mapObj.PriceCost = srcObj.Prices.Single(p => p.Type == PriceType.Cost).Amount;
                        mapObj.PriceTarget = 100;
                        mapObj.PricePremium = 200;
                        mapObj.DateOfProduction = srcObj.DateOfProduction.Date.ToString("dd/MM/yyyy");
                        mapObj.DateOfLastSoldItem = srcObj.DateOfLastSold.Date.ToString("dd/MM/yyyy");

                        return mapObj;
                    }

                case "BusinessItem":
                    {
                        var srcObj = new BusinessItemIModel();
                        srcObj.CopyPropertiesFrom(src);

                        var mapObj = new BusinessItem();

                        mapObj.Id = srcObj.Id;
                        mapObj.ItemId = srcObj.ItemId;
                        mapObj.Item = new Item();
                        mapObj.Item.Id = srcObj.ItemId;
                        mapObj.Item.Name = srcObj.Name;
                        mapObj.Item.Description = srcObj.Description;
                        mapObj.Item.GroupId = srcObj.GroupId;
                        mapObj.Quantity = srcObj.Quantity;
                        mapObj.Prices = new List<Price>();
                        mapObj.Prices.Add(new Price() { BusinessItemId = srcObj.Id, Type = PriceType.Cost, Amount = srcObj.PriceCost });
                        mapObj.DateOfProduction = DateTime.ParseExact(srcObj.DateOfProduction, "dd/MM/yyyy", new CultureInfo("en-US"));
                        mapObj.DateOfLastSold = DateTime.ParseExact(srcObj.DateOfLastSold, "dd/MM/yyyy", new CultureInfo("en-US"));

                        return mapObj;
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
                    throw new Exception($"No implementation to map ${mapModel.Name} model!");
            }
        }
    }
}
