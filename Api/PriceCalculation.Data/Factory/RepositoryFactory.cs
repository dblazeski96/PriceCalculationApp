using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;

namespace PriceCalculation.Data.Factory
{
    public static class RepositoryFactory
    {
        public static T Create<T>(DbContext dbContext) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IBusinessEntityRepository":
                    return (T)Activator.CreateInstance(typeof(BusinessEntityRepository), new object[] { dbContext });

                case "IBusinessItemRepository":
                    return (T)Activator.CreateInstance(typeof(BusinessItemRepository), new object[] { dbContext });

                case "ICatalogueRepository":
                    return (T)Activator.CreateInstance(typeof(CatalogueRepository), new object[] { dbContext });

                case "IGroupRepository":
                    return (T)Activator.CreateInstance(typeof(GroupRepository), new object[] { dbContext });

                case "IRuleRepository":
                    return (T)Activator.CreateInstance(typeof(RuleRepository), new object[] { dbContext });

                case "IStrategyRepository":
                    return (T)Activator.CreateInstance(typeof(StrategyRepository), new object[] { dbContext });

                default:
                    throw new WebException("Repository isn't registered");
            }
        }
    }
}
