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
using System.Net;

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
            UpdateBaseModels(item);
        }

        private void UpdateBaseModels(object item)
        {
            var dbEntityEntry = _dbContext.Entry(item);
            dbEntityEntry.State = EntityState.Modified;

            var itemType = item.GetType();

            var includableProps = itemType.GetIncludableProps(false);

            foreach (var prop in includableProps)
            {
                var recursiveItem = itemType.GetProperty(prop.PropertyType.Name).GetValue(item);
                if (recursiveItem != null)
                {
                    UpdateBaseModels(itemType.GetProperty(prop.PropertyType.Name).GetValue(item));
                }
            }
        }

        private void UpdateCollections(IEnumerable items)
        {
            var itemType = items.GetType().GetGenericArguments().Single();
            var includableProps = itemType.GetIncludableProps(true, false);

            foreach (var item in items)
            {
                var dbEntityEntry = _dbContext.Entry(item);
                dbEntityEntry.State = EntityState.Modified;

                foreach (var prop in includableProps)
                {
                    var recursiveItem = itemType.GetProperty(prop.Name).GetValue(item);
                    if (recursiveItem != null)
                    {
                        //UpdateCollections
                    }
                }


            }

            

            

            
        }

        public virtual void Remove(int id)
        {
            IDbSet<T> dbSet = _dbContext.Set<T>();

            var itemToRemove = dbSet.Find(id);

            dbSet.Remove(itemToRemove);
        }

        public virtual T Get(int id)
        {
            IEnumerable<T> items = GetAll(null, null);

            foreach (var item in items)
            {
                if ((int)
                    item.GetType()
                    .GetProperty("Id")
                    .GetValue(item) == id)
                {
                    return item;
                }
            }

            throw new WebException("Item not found!");
        }

        public virtual IEnumerable<T> GetAll(string property, string searchCriteria)
        {
            var dbSet = _dbContext.Set<T>().AsQueryable();
            var TIncludableProps = typeof(T).GetIncludableProps();

            foreach (var prop in TIncludableProps)
            {
                dbSet = dbSet.Include(prop.Name);
            }

            var items = dbSet.ToList();

            if (searchCriteria == "" || searchCriteria == null)
            {
                return items;
            }

            var itemsFiltered = items.Where(i => 
                i.GetType()
                .GetProperty(property)
                .GetValue(i)
                .ToString().ToLower()
                .Contains(searchCriteria.ToLower())
            );

            return itemsFiltered;
        }

        
    }
}
