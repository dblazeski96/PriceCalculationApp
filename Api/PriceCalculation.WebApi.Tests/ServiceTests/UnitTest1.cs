using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculation.Data.UnitOfWork;
using PriceCalculation.Data.Models;
using PriceCalculation.Mapper;
using PriceCalculation.Service;
using PriceCalculation.Data;
using System.Collections.Generic;

namespace PriceCalculation.WebApi.Tests.ServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var _searchUoW = new SearchUoW(new PriceCalculationContext());

            var items = _searchUoW._businessItemRepository.GetAll();
        }
    }
}
