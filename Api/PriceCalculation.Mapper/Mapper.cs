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
        /// <summary>
        ///     Maps a Data Model to a View Model
        /// </summary>
        /// <param name="src">Data Model that </param>
        /// <param name="mapModel"></param>
        /// <returns></returns>
        public static T MapToViewModel<T>(this BaseDataModel src)
            where T : class, BaseViewModel
        {
            var mapType = typeof(T);

            switch (mapType.Name)
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

                        var map = (T)Activator.CreateInstance(mapType);
                        map.CopyPropertiesFrom(mapObj);

                        return map;
                    }

                case "BusinessEntityOModel":
                    {
                        var srcObj = new BusinessEntity();
                        srcObj.CopyPropertiesFrom(src);

                        var mapObj = new BusinessEntityOModel();

                        mapObj.Id = srcObj.Id;
                        mapObj.Name = srcObj.Name;
                        mapObj.Type = srcObj.Type.ToString();
                        mapObj.Currency = srcObj.Currency.ToString();

                        var map = (T)Activator.CreateInstance(mapType);
                        map.CopyPropertiesFrom(mapObj);

                        return map;
                    }

                default:
                    throw new Exception($"No implementation to map ${mapType.Name}!");
            }
        }

        // Maps a ViewModel to DataModel
        public static T MapToDataModel<T>(this BaseViewModel src)
            where T : class, BaseDataModel
        {
            var mapType = typeof(T);

            switch (mapType.Name)
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

                        var map = (T)Activator.CreateInstance(mapType);
                        map.CopyPropertiesFrom(mapObj);

                        return map;
                    }

                case "BusinessEntity":
                    {
                        var srcObj = new BusinessEntityIModel();
                        srcObj.CopyPropertiesFrom(src);

                        var mapObj = new BusinessEntity
                        {

                        };

                        var map = (T)Activator.CreateInstance(mapType);
                        map.CopyPropertiesFrom(mapObj);

                        return map;
                    }

                default:
                    throw new Exception($"No implementation to map {mapType.Name}!");
            }
        }
    }
}
