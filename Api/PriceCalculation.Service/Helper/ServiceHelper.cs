using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.UnitOfWork;
using PriceCalculation.Models.Base;
using PriceCalculation.Models.Data;

namespace PriceCalculation.Service
{
    public static class ServiceHelper
    {
        // Determines DataModel object from ViewModel object.
        public static Type GetDataModelType<TOutput>()
            where TOutput : class, BaseViewModel
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

        // Save all database changes from all DbContext objects that a given service is using.
        public static void SaveChanges(IEnumerable<IUnitOfWork> uoWs)
        {
            foreach (var uoW in uoWs)
            {
                uoW.Commit();
            }
        }

        // Returns all Unit of Works for a given service.
        public static IEnumerable<IUnitOfWork> GetServiceUoWs(IService service)
        {
            var serviceUoWs = service.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => typeof(IUnitOfWork).IsAssignableFrom(f.FieldType));

            if (serviceUoWs.Any())
            {
                return serviceUoWs.Select(u => (IUnitOfWork)u.GetValue(service));
            }

            throw new WebException("Service does not contain any Unit Of Work!");
        }

        // Determines a repository from a ViewModel object.
        public static object DetermineRepository<TOutput>(IService service)
            where TOutput : class, BaseViewModel
        {
            var serviceUoWs = ServiceHelper.GetServiceUoWs(service);
            var dataModelType = ServiceHelper.GetDataModelType<TOutput>();
            var repository = ServiceHelper.FindRepository(dataModelType, serviceUoWs);

            return repository;
        }

        // Searches the repository within all assemblies
        private static object FindRepository(Type dataModelType, IEnumerable<IUnitOfWork> uoWs)
        {
            Type repositoryType = typeof(IRepository<>).MakeGenericType(dataModelType);

            foreach (var uoW in uoWs)
            {
                var uoWRepositories = uoW.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(r => repositoryType.IsAssignableFrom(r.PropertyType));

                if (uoWRepositories.Any())
                {
                    return uoWRepositories.Select(r => r.GetValue(uoW)).First();
                }
            }

            throw new WebException("Repository does not exist in any Unit of Work!");
        }
    }
}
