using PriceCalculation.Data.Factory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.UnitOfWork
{
    public class BaseUoW<Context> : IUnitOfWork where Context : DbContext
    {
        protected DbContext _dbContext;

        public BaseUoW()
        {
            _dbContext = ContextFactory<Context>.Create();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
