using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;
using PriceCalculation.Models.Data;
using PriceCalculation.Models.View;

namespace PriceCalculation.Mapper
{
    public static class Mapper
    {
        // Maps DataModel to ViewModel
        public static BaseViewModel MapToViewModel(this object src, Type mapModel)
        {
            switch (mapModel.Name)
            {
                case "BusinessItemOModel":
                    {
                        var srcObj = new BusinessItem();
                        srcObj.CopyPropertiesFrom(src);

                        var mapObj = new BusinessItemOModel()
                        {
                            Id = srcObj.Id,
                            Name = srcObj.Item.Name,
                            Description = srcObj.Item.Description,
                            Group = srcObj.Item.Group.Name,
                            Quantity = srcObj.Quantity,
                            PriceCost = srcObj.Prices.Single(p => p.Type == PriceType.Cost).Amount,
                            PriceTarget = 100,
                            PricePremium = 200,
                            DateOfProduction = srcObj.DateOfProduction.Date.ToString("dd/MM/yyyy"),
                            DateOfLastSoldItem = srcObj.DateOfLastSold.Date.ToString("dd/MM/yyyy")
                        };

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
                    throw new Exception($"No implementation to map ${mapModel.Name}!");
            }
        }

        // Maps a ViewModel to DataModel
        public static BaseDataModel MapToDataModel(this object src, Type mapModel)
        {
            switch (mapModel.Name)
            {
                case "BusinessItem":
                    {
                        var srcObj = new BusinessItemIModel();
                        srcObj.CopyPropertiesFrom(src);

                        var mapObj = new BusinessItem
                        {
                            Id = srcObj.Id,
                            ItemId = srcObj.ItemId,
                            Item = new Item
                            {
                                Id = srcObj.ItemId,
                                Name = srcObj.Name,
                                Description = srcObj.Description,
                                GroupId = srcObj.GroupId,
                                Group = null
                            },
                            Quantity = srcObj.Quantity,
                            Prices = new List<Price>
                            {
                                new Price
                                {
                                    Type = PriceType.Cost,
                                    Amount = srcObj.PriceCost,
                                    BusinessItemId = srcObj.Id,
                                    BusinessItem = null
                                }
                            },
                            DateOfProduction = DateTime.ParseExact(srcObj.DateOfProduction, "dd/MM/yyyy", new CultureInfo("en-US")),
                            DateOfLastSold = DateTime.ParseExact(srcObj.DateOfLastSold, "dd/MM/yyyy", new CultureInfo("en-US")),
                            Catalogues = null,
                        };

                        return mapObj;
                    }

                default:
                    throw new Exception($"No implementation to map ${mapModel.Name}!");
            }
        }
    }
}
