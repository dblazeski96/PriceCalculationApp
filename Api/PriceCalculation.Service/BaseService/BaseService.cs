using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using PriceCalculation.Mapper;
using PriceCalculation.Models.Base;
using PriceCalculation.Data.Repository;

namespace PriceCalculation.Service
{
    public abstract class BaseService : IService
    {
        // Service CRUD: Create
        public virtual ServiceResult<TOutput> Create<TInput, TOutput>(TInput item)
            where TInput : class, BaseViewModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repository = ServiceHelper.DetermineRepository<TOutput>(this);

                var itemDataType = ServiceHelper.GetDataModelType<TOutput>();
                var itemDataModel = item.MapToDataModel(itemDataType);

                //repository.Create(itemDataModel);
                repository.GetType().GetMethod("Create").Invoke(repository, new object[] { itemDataModel });

                ServiceHelper.SaveChanges(ServiceHelper.GetServiceUoWs(this));

                return new ServiceResult<TOutput>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // Service CRUD: Change
        public virtual ServiceResult<TOutput> Change<TInput, TOutput>(TInput item)
            where TInput : class, BaseViewModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repository = ServiceHelper.DetermineRepository<TOutput>(this);

                var itemDataType = ServiceHelper.GetDataModelType<TOutput>();
                var itemDataModel = item.MapToDataModel(itemDataType);

                //repository.Change(itemDataModel);
                repository.GetType().GetMethod("Change").Invoke(repository, new object[] { itemDataModel });

                ServiceHelper.SaveChanges(ServiceHelper.GetServiceUoWs(this));

                return new ServiceResult<TOutput>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // Service CRUD: Remove
        public virtual ServiceResult<TOutput> Remove<TOutput>(int id)
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repository = ServiceHelper.DetermineRepository<TOutput>(this);

                //repository.Remove(id);
                repository.GetType().GetMethod("Remove").Invoke(repository, new object[] { id });

                ServiceHelper.SaveChanges(ServiceHelper.GetServiceUoWs(this));

                return new ServiceResult<TOutput>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // Service CRUD: Get
        public virtual ServiceResult<TOutput> Get<TOutput>(int id)
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repository = ServiceHelper.DetermineRepository<TOutput>(this);

                //var item = (TOutput)repository.Get(id);
                var item = repository.GetType().GetMethod("Get").Invoke(repository, new object[] { id });
                var itemViewModel = (TOutput)item.MapToViewModel(typeof(TOutput));

                return new ServiceResult<TOutput>
                {
                    Success = true,
                    Item = itemViewModel
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        // Service CRUD: GetAll
        public virtual ServiceResult<TOutput> GetAll<TOutput>(string property, string searchCriteria)
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repository = ServiceHelper.DetermineRepository<TOutput>(this);

                //var items = repository.GetAll(property, searchCriteria);
                var items = (IEnumerable<object>)repository.GetType().GetMethod("GetAll").Invoke(repository, new object[] { property, searchCriteria });

                var itemViewModels = new List<TOutput>();
                foreach (var i in items)
                {
                    itemViewModels.Add((TOutput)i.MapToViewModel(typeof(TOutput)));
                }

                return new ServiceResult<TOutput>
                {
                    Success = true,
                    Items = itemViewModels
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }

        }
    }
}
