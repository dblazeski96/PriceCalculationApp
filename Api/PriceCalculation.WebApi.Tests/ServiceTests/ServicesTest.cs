using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculation.Data.UnitOfWork;
using PriceCalculation.Data.Models;
using PriceCalculation.Mapper;
using PriceCalculation.Service;
using PriceCalculation.Data;
using System.Collections.Generic;
using PriceCalculation.ViewModels;

namespace PriceCalculation.WebApi.Tests.ServiceTests
{
    [TestClass]
    public class ServicesTest
    {
        [TestMethod]
        public void SearchService()
        {
            //Arrange
            var item1 = new BusinessItem
            {
                Id = 1,
                Quantity = 3,
                ItemId = 1,
                DateOfLastSold = new DateTime(2018, 08, 27),
                DateOfProduction = new DateTime(2017, 03, 24),
                Item = new Item
                {
                    Id = 1,
                    Name = "Item 1 name",
                    GroupId = 1,
                    Description = "Item 1 description",
                    Group = new Group
                    {
                        Id = 1,
                        Items = new List<Item>(),
                        Name = "Group name",
                        StrategyId = 1
                    }
                },
                Catalogues = new List<CatalogueItem>(),
                Prices = new List<Price>()
            };
            var searchService = new SearchService(new PriceCalculationUoW<PriceCalculationContext>());

            //Act
            var itemGet = searchService.Get<BusinessItemViewModel, BusinessItem>(1);
            searchService.Create<BusinessItemViewModel, BusinessItem>(item1);

            //Assert
        }
    }
}
