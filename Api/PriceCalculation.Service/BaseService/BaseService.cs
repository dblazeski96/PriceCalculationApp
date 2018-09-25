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

namespace PriceCalculation.Service
{
    public abstract class BaseService : IService
    {
        protected virtual IRepository<T> DetermineRepository<T>(IService service)
            where T : class
        {
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

                IRepository<T> repository = (IRepository<T>)uoWProps.Single(
                    prop => typeof(IRepository<T>).IsAssignableFrom(prop.PropertyType))
                    .GetValue(uoW.GetValue(this));

                if (repository != null)
                {
                    return repository;
                }
            }

            throw new Exception("Repository not found!");
        }

        private ServiceResult<TViewModel> ExecuteRepositoryMethod<TViewModel, T>(string methodName, object[] parameters)
            where T : class
            where TViewModel : class
        {
            try
            {
                IRepository<T> repository = DetermineRepository<T>(this);

                switch (methodName)
                {
                    case "Create":
                    case "Change":
                    case "Remove":
                        repository.GetType().GetMethod(methodName).Invoke(repository, parameters);

                        return new ServiceResult<TViewModel>
                        {
                            Success = true
                        };

                    case "Get":
                        TViewModel item = repository.GetType().GetMethod(methodName).Invoke(repository, parameters).Map<TViewModel>();

                        return new ServiceResult<TViewModel>
                        {
                            Success = true,
                            Item = item
                        };

                    case "GetAll":
                        IList<T> items = (IList<T>)repository.GetType().GetMethod(methodName).Invoke(repository, parameters);
                        ICollection<TViewModel> itemsViewModel = new List<TViewModel>();

                        foreach (var i in items)
                        {
                            itemsViewModel.Add(i.Map<TViewModel>());
                        }

                        return new ServiceResult<TViewModel>
                        {
                            Success = true,
                            Items = itemsViewModel.ToList()
                        };

                    default:
                        return new ServiceResult<TViewModel>
                        {
                            Success = false,
                            ex = new Exception("Method doesn't exist!")
                        };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<TViewModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        public virtual ServiceResult<TViewModel> Create<TViewModel, T>(T item)
            where T : class
            where TViewModel : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Create", new object[] { item });
        }

        public virtual ServiceResult<TViewModel> Change<TViewModel, T>(T item)
            where T : class
            where TViewModel : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Change", new object[] { item });
        }

        public virtual ServiceResult<TViewModel> Remove<TViewModel, T>(int id)
            where T : class
            where TViewModel : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Remove", new object[] { id });
        }

        public virtual ServiceResult<TViewModel> Get<TViewModel, T>(int id)
            where T : class
            where TViewModel : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Get", new object[] { id });
        }

        public virtual ServiceResult<TViewModel> GetAll<TViewModel, T>()
            where T : class
            where TViewModel : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("GetAll", new object[] { });
        }
    }
}
