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
using PriceCalculation.Data.Models;

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
            UpdateCollections(item);
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
                    UpdateBaseModels(recursiveItem);
                }
            }
        }

        private void UpdateCollections(object item)
        {
            var itemType = item.GetType();
            var includableCollections = itemType.GetIncludableProps(true, false);

            foreach (var collectionProp in includableCollections)
            {
                var collection = (ICollection)itemType.GetProperty(collectionProp.Name).GetValue(item);
                
                if (collection != null)
                {
                    foreach (var collectionItem in collection)
                    {
                        var dbEntityEntry = _dbContext.Entry(collectionItem);
                        dbEntityEntry.State = EntityState.Modified;

                        if (collectionItem != null)
                        {
                            UpdateCollections(collectionItem);
                        }
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

            var includableProps = DetermineIncludableProps(typeof(T), null, new List<string>(), new List<string>());

            foreach (var prop in includableProps)
            {
                dbSet = dbSet.Include(prop);
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

        private ICollection<string> DetermineIncludableProps(Type item, string parentItemPath, ICollection<string> includedPropPaths, ICollection<string> includedProps)
        {
            var includableProps = item.GetIncludableProps(false);

            foreach (var prop in includableProps)
            {
                var propType = prop.PropertyType;
                if (typeof(IEnumerable<BaseModel>).IsAssignableFrom(propType))
                {
                    propType = propType.GetGenericArguments().Single();
                }

                if (!includedProps.Contains(propType.Name))
                {
                    includedProps.Add(propType.Name);

                    var itemPath = parentItemPath == null || parentItemPath == "" ? prop.Name : parentItemPath + "." + prop.Name;

                    includedPropPaths.Add(itemPath);

                    DetermineIncludableProps(prop.PropertyType, itemPath, includedPropPaths, includedProps);
                }
            }

            return includedPropPaths;
        }
    }
}
