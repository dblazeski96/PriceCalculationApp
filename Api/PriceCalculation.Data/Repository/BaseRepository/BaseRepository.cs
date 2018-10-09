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
    public abstract partial class BaseRepository<T> : IRepository<T>
        where T : class, BaseDataModel
    {
        protected readonly DbContext _dbContext;
    
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CRUD: Create 
        public virtual RepositoryResult<T> Create(T item) // Need to test
        {
            try
            {
                var dbSet = _dbContext.Set<T>();
                dbSet.Add(item);

                return new RepositoryResult<T>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<T>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // CRUD: Change
        public virtual RepositoryResult<T> Change(T item) // Need to finish
        {
            try
            {
                var dbSet = _dbContext.Set<T>();
                var dbSetIncluded = dbSet.IncludePropsToDbSet();

                var itemId = (int)item.GetType().GetProperty("Id").GetValue(item);
                var itemToChange = dbSetIncluded.ToList().Single(i => (int)i.GetType().GetProperty("Id").GetValue(i) == itemId);

                itemToChange.CopyPropertiesFrom(item);

                return new RepositoryResult<T>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<T>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // CRUD: Remove
        public virtual RepositoryResult<T> Remove(int id) // Need to test
        {
            try
            {
                var dbSet = _dbContext.Set<T>();

                var item = dbSet.Find(id);
                dbSet.Remove(item);

                return new RepositoryResult<T>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<T>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // CRUD: Get
        public virtual RepositoryResult<T> Get(int id) // Good
        {
            try
            {
                var dbSet = _dbContext.Set<T>();
                var dbSetIncluded = dbSet.IncludePropsToDbSet();

                var item = dbSetIncluded.ToList().Single(i => (int)i.GetType().GetProperty("Id").GetValue(i) == id);

                return new RepositoryResult<T>
                {
                    Success = true,
                    item = item
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<T>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // CRUD: GetAll
        public virtual RepositoryResult<T> GetAll(string property, string searchCriteria) // Good
        {
            try
            {
                var dbSet = _dbContext.Set<T>();
                var dbSetIncluded = dbSet.IncludePropsToDbSet();

                var items = dbSetIncluded.ToList();

                if (searchCriteria == "" || searchCriteria == null)
                {
                    return new RepositoryResult<T>
                    {
                        Success = true,
                        items = items
                    };
                }

                var itemsFiltered = items.Where(i =>
                    i.GetType()
                    .GetProperty(property)
                    .GetValue(i)
                    .ToString().ToLower()
                    .Contains(searchCriteria.ToLower())
                );

                return new RepositoryResult<T>
                {
                    Success = true,
                    items = itemsFiltered
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<T>
                {
                    Success = false,
                    ex = ex
                };
            }
        }



    }
}
