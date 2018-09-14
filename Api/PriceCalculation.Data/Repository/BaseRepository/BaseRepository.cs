using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Mapper;

namespace PriceCalculation.Data.Repository
{
    public abstract class BaseRepository<Context, T> : IRepository<T> where Context : DbContext where T : class
    {
        protected readonly Context _dbContext;

        public BaseRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Create(T item)
        {
            _dbContext.Set<T>().Add(item);
        }

        public virtual void Change(T item)
        {
            var itemToChange = _dbContext.Set<T>().Find(item);
            itemToChange.CopyProperties(item);
        }

        public virtual void Remove(int id)
        {
            var itemToRemove = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(itemToRemove);
        }

        public virtual T Get(int id)
        {
            var itemToSend = _dbContext.Set<T>().Find(id);
            return itemToSend;
        }

        public virtual IList<T> GetAll()
        {
            var itemsToSend = _dbContext.Set<T>().ToList();
            return itemsToSend;
        }
    }
}
