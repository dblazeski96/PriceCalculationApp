using PriceCalculation.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Factory
{
    public static class RepositoryFactory
    {
        public static dynamic Create<T>(DbContext dbContext) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IBusinessEntityRepository":
                    return Activator.CreateInstance(typeof(BusinessEntityRepository), new object[] { dbContext });

                case "IBusinessItemRepository":
                    return Activator.CreateInstance(typeof(BusinessItemRepository), new object[] { dbContext });

                case "ICatalogueRepository":
                    return Activator.CreateInstance(typeof(CatalogueRepository), new object[] { dbContext });

                case "IGroupRepository":
                    return Activator.CreateInstance(typeof(GroupRepository), new object[] { dbContext });

                case "IRuleRepository":
                    return Activator.CreateInstance(typeof(RuleRepository), new object[] { dbContext });

                case "IStrategyRepository":
                    return Activator.CreateInstance(typeof(StrategyRepository), new object[] { dbContext });

                default:
                    throw new WebException("Repository isn't registered");
            }
        }
    }
}
