using PriceCalculation.Data.Repository;
using PriceCalculation.Data.UnitOfWork;
using PriceCalculation.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace PriceCalculation.Service
{
    public abstract class BaseService : IService
    {
        private ServiceResult<TOutput> ExecuteRepositoryMethod<TOutput>(string methodName, object[] parameters)
            where TOutput : class
        {
            try
            {
                var serviceUoWs = ServiceHelper.GetServiceUoWs(this);
                var dataModelType = ServiceHelper.GetDataModelType<TOutput>();
                var repository = ServiceHelper.DetermineRepository(dataModelType, serviceUoWs);

                switch (methodName)
                {
                    case "Create":
                    case "Change":
                    case "Remove":
                        repository.GetType().GetMethod(methodName).Invoke(repository, parameters);

                        return new ServiceResult<TOutput>
                        {
                            Success = true
                        };

                    case "Get":
                        var item = repository.GetType().GetMethod(methodName).Invoke(repository, parameters).Map(typeof(TOutput));

                        return new ServiceResult<TOutput>
                        {
                            Success = true,
                            Item = item
                        };

                    case "GetAll":
                        var items = (IEnumerable)repository.GetType().GetMethod(methodName).Invoke(repository, parameters);
                        ICollection<TOutput> itemsViewModel = new List<TOutput>();

                        foreach (var i in items)
                        {
                            itemsViewModel.Add(i.Map(typeof(TOutput)));
                        }

                        return new ServiceResult<TOutput>
                        {
                            Success = true,
                            Items = itemsViewModel.ToList()
                        };

                    default:
                        return new ServiceResult<TOutput>
                        {
                            Success = false,
                            ex = new WebException("Method doesn't exist!")
                        };
                }
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

        public virtual ServiceResult<TOutput> Create<TInput, TOutput>(TInput item)
            where TInput : class
            where TOutput : class
        {
            var dataModelType = ServiceHelper.GetDataModelType<TOutput>();
            var itemDataModel = item.Map(dataModelType);

            var serviceResult = ExecuteRepositoryMethod<TOutput>("Create", new object[] { itemDataModel });

            var serviceUoWs = ServiceHelper.GetServiceUoWs(this);
            foreach (var uoW in serviceUoWs)
            {
                uoW.Commit();
            }

            return serviceResult;
        }

        public virtual ServiceResult<TOutput> Change<TInput, TOutput>(TInput item)
            where TInput : class
            where TOutput : class
        {
            var dataModelType = ServiceHelper.GetDataModelType<TOutput>();
            var itemDataModel = item.Map(dataModelType);

            var serviceResult = ExecuteRepositoryMethod<TOutput>("Change", new object[] { itemDataModel });

            var serviceUoWs = ServiceHelper.GetServiceUoWs(this);
            foreach (var uoW in serviceUoWs)
            {
                uoW.Commit();
            }

            return serviceResult;
        }

        public virtual ServiceResult<TOutput> Remove<TOutput>(int id)
            where TOutput : class
        {
            var serviceResult = ExecuteRepositoryMethod<TOutput>("Remove", new object[] { id });

            var serviceUoWs = ServiceHelper.GetServiceUoWs(this);
            foreach (var uoW in serviceUoWs)
            {
                uoW.Commit();
            }

            return serviceResult;
        }

        public virtual ServiceResult<TOutput> Get<TOutput>(int id)
            where TOutput : class
        {
            return ExecuteRepositoryMethod<TOutput>("Get", new object[] { id });
        }

        public virtual ServiceResult<TOutput> GetAll<TOutput>(string property, string searchCriteria)
            where TOutput : class
        {
            return ExecuteRepositoryMethod<TOutput>("GetAll", new object[] { property, searchCriteria });
        }
    }
}
