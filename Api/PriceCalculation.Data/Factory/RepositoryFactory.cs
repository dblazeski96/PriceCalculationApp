using PriceCalculation.Data.Repository;
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
        public static T Create(DbContext dbContext)
        {
            return (T)Activator.CreateInstance(typeof(T), dbContext);
        }
    }
}
