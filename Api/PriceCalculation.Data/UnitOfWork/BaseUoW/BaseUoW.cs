using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Factory;
using System.Runtime.InteropServices;

namespace PriceCalculation.Data.UnitOfWork
{
    public class BaseUoW : IDisposable
    {
        protected readonly Dictionary<Type, DbContext> _dbContexts;

        public BaseUoW(DbContext[] dbContexts)
        {
            _dbContexts = new Dictionary<Type, DbContext>();

            foreach (var _dbContext in dbContexts)
            {
                _dbContexts.Add(_dbContext.GetType(), _dbContext);
            }
        }
        public BaseUoW(DbContext dbContext)
        {
            _dbContexts = new Dictionary<Type, DbContext>();

            _dbContexts.Add(dbContext.GetType(), dbContext);
        }

        public void Commit(Type dbContext)
        {
            _dbContexts[dbContext].SaveChanges();
        }

        public void CommitAll()
        {
            foreach (var dbContext in _dbContexts)
            {
                dbContext.Value.SaveChanges();
            }
        }

        public void DisposeOne(Type dbContext)
        {
            _dbContexts[dbContext].Dispose();
        }

        public void Dispose()
        {
            foreach (var dbContext in _dbContexts)
            {
                dbContext.Value.Dispose();
            }
        }
    }
}
