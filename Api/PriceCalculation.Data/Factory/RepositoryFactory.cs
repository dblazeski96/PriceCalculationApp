﻿using PriceCalculation.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Factory
{
    public static class RepositoryFactory<T> where T : class
    {
        public static dynamic Create(DbContext dbContext)
        {
            switch (typeof(T).Name)
            {
                case "IBusinessItemRepository":
                    return Activator.CreateInstance(typeof(BusinessItemRepository), new object[] { dbContext });

                default:
                    throw new Exception("Repository isn't registered");
            }
        }
    }
}