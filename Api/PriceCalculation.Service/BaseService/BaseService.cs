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

namespace PriceCalculation.Service
{
    public abstract class BaseService : IService
    {
        protected object DetermineRepository<TOutput>(IService service)
            where TOutput : class
        {
            Type dataModelType = Helper.GetDataModelType<TOutput>();
            Type repositoryType = typeof(IRepository<>).MakeGenericType(dataModelType);

            IEnumerable<FieldInfo> serviceUoWs = new List<FieldInfo>(
                service.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                .Where(
                    field => typeof(IUnitOfWork).IsAssignableFrom(field.FieldType)
                );

            foreach (var uoW in serviceUoWs)
            {
                IEnumerable<PropertyInfo> uoWProps = new List<PropertyInfo>(
                uoW.FieldType
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));

                var repository = uoWProps.Single(
                    prop => repositoryType.IsAssignableFrom(prop.PropertyType))
                    .GetValue(uoW.GetValue(this));

                if (repository != null)
                {
                    return repository;
                }
            }

            throw new Exception("Repository not found!");
        }

        private ServiceResult<TOutput> ExecuteRepositoryMethod<TOutput>(string methodName, object[] parameters)
            where TOutput : class
        {
            try
            {
                var repository = DetermineRepository<TOutput>(this);

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
                        var item = repository.GetType().GetMethod(methodName).Invoke(repository, parameters).Map<TOutput>();

                        return new ServiceResult<TOutput>
                        {
                            Success = true,
                            Item = item
                        };

                    case "GetAll":
                        var items = (IList)repository.GetType().GetMethod(methodName).Invoke(repository, parameters);
                        ICollection<TOutput> itemsViewModel = new List<TOutput>();

                        foreach (var i in items)
                        {
                            itemsViewModel.Add(i.Map<TOutput>());
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
                            ex = new Exception("Method doesn't exist!")
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
            return ExecuteRepositoryMethod<TOutput>("Create", new object[] { item });
        }

        public virtual ServiceResult<TOutput> Change<TInput, TOutput>(TInput item)
            where TInput : class
            where TOutput : class
        {
            return ExecuteRepositoryMethod<TOutput>("Change", new object[] { item });
        }

        public virtual ServiceResult<TOutput> Remove<TOutput>(int id)
            where TOutput : class
        {
            return ExecuteRepositoryMethod<TOutput>("Remove", new object[] { id });
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
