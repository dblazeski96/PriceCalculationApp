using PriceCalculation.Data.Factory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.UnitOfWork
{
    public abstract class BaseUoW<Context> : IUnitOfWork 
        where Context : DbContext
    {
        protected DbContext _dbContext;

        public BaseUoW()
        {
            _dbContext = ContextFactory.Create<Context>();
        }

        public virtual void Commit()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
