using PriceCalculation.Data.Models;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public static class ServiceHelper
    {
        public static Type GetDataModelType<TOutput>()
        {
            string dataModelName = typeof(TOutput).Name.Replace("OModel", "");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var models = assembly.GetTypes().Where(m => m.Name == dataModelName);
                if (models.Any())
                {
                    return models.First();
                }
            }

            throw new WebException("Data model does not exist!");
        }

        public static IEnumerable<IUnitOfWork> GetServiceUoWs(IService service)
        {
            var serviceUoWs = service.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => typeof(IUnitOfWork).IsAssignableFrom(f.FieldType));

            if (serviceUoWs.Any())
            {
                return serviceUoWs.Select(f => (IUnitOfWork)f.GetValue(service));
            }

            throw new WebException("Service does not contain any Unit Of Work!");
        }

        public static object DetermineRepository(Type dataModelType, IEnumerable<IUnitOfWork> uoWs)
        {
            Type repositoryType = typeof(IRepository<>).MakeGenericType(dataModelType);

            foreach (var uoW in uoWs)
            {
                var uoWRepositories = uoW.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(p => repositoryType.IsAssignableFrom(p.PropertyType));

                if (uoWRepositories.Any())
                {
                    return uoWRepositories.Select(r => r.GetValue(uoW)).First();
                }
            }

            throw new WebException("Repository does not exist in any Unit of Work!");
        }
    }
}
