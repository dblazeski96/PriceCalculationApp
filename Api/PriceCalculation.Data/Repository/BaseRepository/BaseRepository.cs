using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Linq.Expressions;
using PriceCalculation.Mapper;

namespace PriceCalculation.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Create(T item)
        {
            IDbSet<T> dbSet = _dbContext.Set<T>();

            dbSet.Add(item);
        }

        public virtual void Change(T item)
        {
            IDbSet<T> dbSet = _dbContext.Set<T>();

            var itemToChange = dbSet.Find((int)item.GetType().GetProperty("Id").GetValue(item));

            itemToChange.CopyPropertiesFrom(item);
        }

        public virtual void Remove(int id)
        {
            IDbSet<T> dbSet = _dbContext.Set<T>();

            var itemToRemove = dbSet.Find(id);

            dbSet.Remove(itemToRemove);
        }

        public virtual T Get(int id)
        {
            IList<T> items = GetAll();

            foreach (var item in items)
            {
                if (
                    (int)item
                        .GetType()
                        .GetProperty("Id")
                        .GetValue(item)
                    == id)
                {
                    return item;
                }
            }

            throw new Exception("Item not found!");
        }

        public virtual IList<T> GetAll()
        {
            IEnumerable<PropertyInfo> TIncludableProps = new List<PropertyInfo>(
                    typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                ).GetIncludableProps();

            IQueryable<T> dbSet = _dbContext.Set<T>();

            foreach (var prop in TIncludableProps)
            {
                dbSet = dbSet.Include(prop.Name);
            }

            return dbSet.ToList();
        }
    }
}
