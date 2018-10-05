using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PriceCalculation.Mapper;
using System.Net;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class, BaseDataModel
    {
        protected readonly DbContext _dbContext;
    
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CRUD: Create 
        public virtual void Create(T item) // Need to test
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Add(item);
        }

        // CRUD: Change
        public virtual void Change(T item) // Need to finish
        {
            var dbSet = _dbContext.Set<T>();
            var dbSetIncluded = dbSet.IncludePropsToDbSet();
        }

        //private void UpdateBaseModels(object item)
        //{
        //    var dbEntityEntry = _dbContext.Entry(item);
        //    dbEntityEntry.State = EntityState.Modified;

        //    var itemType = item.GetType();

        //    var includableProps = itemType.GetIncludableProps(false);

        //    foreach (var prop in includableProps)
        //    {
        //        var recursiveItem = itemType.GetProperty(prop.PropertyType.Name).GetValue(item);
        //        if (recursiveItem != null)
        //        {
        //            UpdateBaseModels(recursiveItem);
        //        }
        //    }
        //}

        //private void UpdateCollections(object item)
        //{
        //    var itemType = item.GetType();
        //    var includableCollections = itemType.GetIncludableProps(true, false);

        //    foreach (var collectionProp in includableCollections)
        //    {
        //        var collection = (ICollection)itemType.GetProperty(collectionProp.Name).GetValue(item);
                
        //        if (collection != null)
        //        {
        //            foreach (var collectionItem in collection)
        //            {
        //                var dbEntityEntry = _dbContext.Entry(collectionItem);
        //                dbEntityEntry.State = EntityState.Modified;

        //                if (collectionItem != null)
        //                {
        //                    UpdateCollections(collectionItem);
        //                }
        //            }
        //        }
        //    }
        //}


        // CRUD: Remove
        public virtual void Remove(int id) // Need to test
        {
            var dbSet = _dbContext.Set<T>();

            var item = dbSet.Find(id);
            dbSet.Remove(item);
        }

        // CRUD: Get
        public virtual T Get(int id) // Good
        {
            var dbSet = _dbContext.Set<T>();
            var dbSetIncluded = dbSet.IncludePropsToDbSet();

            var item = dbSetIncluded.ToList().Single(i => (int)i.GetType().GetProperty("Id").GetValue(i) == id);

            return item;
        }

        // CRUD: GetAll
        public virtual IEnumerable<T> GetAll(string property, string searchCriteria) // Good
        {
            var dbSet = _dbContext.Set<T>();
            var dbSetIncluded = dbSet.IncludePropsToDbSet();

            var items = dbSetIncluded.ToList();

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
