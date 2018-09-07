using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculation.Service;
using PriceCalculation.ViewModels;
using PriceCalculation.Data.Models;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;

namespace PriceCalculation.WebApi.Tests.ServiceTests
{
    [TestClass]
    public class BusinessItemServiceTest
    {
        [TestMethod]
        public async Task GetItemById()
        {
            //Arrange
            var id1 = 1;
            var id2 = 2;
            var id3 = 3;

            //Act
            BusinessItemService businessItemService = new BusinessItemService(new BusinessItemRepository());
            var bItem1Result = await businessItemService.Get(id1);
            var bItem2Result = await businessItemService.Get(id2);
            var bItem3Result = await businessItemService.Get(id3);

            //Assert
            Assert.IsNotNull(bItem1Result);
        }

        [Ignore]
        [TestMethod]
        public async Task Changeitem()
        {
            //Arrange
            var item1 = new BusinessItem
            {
                Id = 1,
                Quantity = 321,
                DateOfProduction = new DateTime(2017, 2, 3),
                DateOfLastSold = new DateTime(2018, 9, 2),
                Prices = new List<Price>
                {
                    new Price
                    {
                        Type = PriceType.Cost,
                        Amount = 300
                    },
                    new Price
                    {
                        Type = PriceType.Target,
                        Amount = 350
                    },
                    new Price
                    {
                        Type = PriceType.Premium,
                        Amount = 400
                    }
                },
                ItemId = 1,
                Item = new Item
                {
                    Name = "DejanChanged item",
                    Description = "DejanChanged description",
                    GroupId = 2
                }
            };

            var item2 = new BusinessItem
            {
                Id = 2,
                Quantity = 31,
                DateOfProduction = new DateTime(2017, 4, 12),
                DateOfLastSold = new DateTime(2018, 8, 21),
                Prices = new List<Price>
                {
                    new Price
                    {
                        Type = PriceType.Cost,
                        Amount = 100
                    },
                    new Price
                    {
                        Type = PriceType.Target,
                        Amount = 130
                    },
                    new Price
                    {
                        Type = PriceType.Premium,
                        Amount = 210
                    }
                },
                ItemId = 2,
                Item = new Item
                {
                    Name = "MarkoChanged item",
                    Description = "MarkoChanged description",
                    GroupId = 1
                }
            };

            //Act
            BusinessItemService businessItemService = new BusinessItemService(new BusinessItemRepository());
            var item1Result = await businessItemService.Change(item1);
            var item2Result = await businessItemService.Change(item2);

            //Assert
            Assert.IsNotNull(item1Result);
        }
    }
}
