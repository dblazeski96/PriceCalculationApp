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
        /// <summary>
        ///     Saves all changes for a given list of Unit of Work objects.
        /// </summary>
        /// <param name="uoWs">"IEnumerable" of Unit of Work objects that needs to be saved.</param>
        public static void SaveChanges(IEnumerable<IUnitOfWork> uoWs)
        {
            foreach (var uoW in uoWs)
            {
                uoW.Commit();
            }
        }

        /// <summary>
        ///     Determines Data Model object from a View Model object.
        /// </summary>
        /// <typeparam name="TOutput">Type of View Model object.</typeparam>
        /// <returns>Type of Data View Model.</returns>
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

        /// <summary>
        ///     Finds all Unit of Work objects in a given service.
        /// </summary>
        /// <param name="service">Service from which Unit of Work objects need to be determined.</param>
        /// <returns>"IEnumerable" of all Unit of Work objects for a given service.</returns>
        //public static IEnumerable<IUnitOfWork> GetServiceUoWs(IService service)
        //{
        //    var serviceUoWs = service.GetType()
        //        .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
        //        .Where(f => typeof(IUnitOfWork).IsAssignableFrom(f.FieldType));

        //    if (serviceUoWs.Any())
        //    {
        //        return serviceUoWs.Select(u => (IUnitOfWork)u.GetValue(service));
        //    }

        //    throw new WebException("Service does not contain any Unit Of Work!");
        //}

        /// <summary>
        ///     Searches the repository in a list Unit of Work objects
        /// </summary>
        /// <param name="dataModelType">Type of Data Model.</param>
        /// <param name="uoWs">"IEnumerable of Unit of Work objects."</param>
        /// <returns>Object from type "object" that is a repository</returns>
        //private static object FindRepository(Type dataModelType, IEnumerable<IUnitOfWork> uoWs)
        //{
        //    Type repositoryType = typeof(IRepository<>).MakeGenericType(dataModelType);

        //    foreach (var uoW in uoWs)
        //    {
        //        var uoWRepositories = uoW.GetType()
        //            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
        //            .Where(r => repositoryType.IsAssignableFrom(r.PropertyType));

        //        if (uoWRepositories.Any())
        //        {
        //            return uoWRepositories.Select(r => r.GetValue(uoW)).First();
        //        }
        //    }

        //    throw new WebException("Repository does not exist in any Unit of Work!");
        //}

        /// <summary>
        ///     Determines a repository from a View Model and Service.
        /// </summary>
        /// <typeparam name="TOutput">Type of View Model</typeparam>
        /// <param name="service">Service from which a repository needs to be determined.</param>
        /// <returns>Object from type "object" that is a repository.</returns>
        //public static object DetermineRepository<TOutput>(IService service)
        //    where TOutput : class, BaseViewModel
        //{
        //    var serviceUoWs = ServiceHelper.GetServiceUoWs(service);
        //    var dataModelType = ServiceHelper.GetDataModelType<TOutput>();
        //    var repository = ServiceHelper.FindRepository(dataModelType, serviceUoWs);

        //    return repository;
        //}
    }
}
