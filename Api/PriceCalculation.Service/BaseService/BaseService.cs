using PriceCalculation.Data.Repository;
using PriceCalculation.Data.UnitOfWork;
using PriceCalculation.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public class BaseService : IService
    {
        private ServiceResult<TViewModel> ExecuteRepositoryMethod<TViewModel, T>(string methodName, object[] parameters)
            where TViewModel : class
            where T : class
        {
            try
            {
                var serviceFields = new List<FieldInfo>(GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));
                var serviceUoWs = serviceFields.Where(field => typeof(IUnitOfWork).IsAssignableFrom(field.GetValue(this).GetType())).Select(field => field.GetValue(this)).ToList();

                foreach (var uoW in serviceUoWs)
                {
                    var uoWProps = new List<PropertyInfo>(uoW.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance));
                    var repository = uoWProps.Single(prop => typeof(IRepository<T>).IsAssignableFrom(prop.GetValue(uoW).GetType())).GetValue(uoW);
                    if (repository != null)
                    {
                        repository.GetType().GetMethod(methodName).Invoke(repository, parameters);
                        break;
                    }
                }

                return new ServiceResult<TViewModel>
                {
                    Success = true
                };
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

        public ServiceResult<TViewModel> Create<TViewModel, T>(T item)
            where TViewModel : class
            where T : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Create", new object[] { item });
        }

        public ServiceResult<TViewModel> Change<TViewModel, T>(T item)
            where TViewModel : class
            where T : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Change", new object[] { item });
        }

        public ServiceResult<TViewModel> Remove<TViewModel, T>(int id)
            where TViewModel : class
            where T : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Remove", new object[] { id });
        }

        public ServiceResult<TViewModel> Get<TViewModel, T>(int id)
            where TViewModel : class
            where T : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("Get", new object[] { id });
        }

        public ServiceResult<TViewModel> GetAll<TViewModel, T>()
            where TViewModel : class
            where T : class
        {
            return ExecuteRepositoryMethod<TViewModel, T>("GetAll", new object[] { });
        }
    }
}
