using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;
using System.Data.Entity;

namespace PriceCalculation.Mapper
{
    public static class Helper
    {
        /// <summary>
        ///     Copy all properties that have the same name and type from any object.
        /// </summary>
        /// <param name="src">Object that the properties are copied to.</param>
        /// <param name="obj">Object that the properties are copied from.</param>
        /// <param name="copyId">Bool that indicates whether ID property should be copied.</param>
        public static void CopyPropertiesFrom(this BaseModel src, object obj, bool copyId = true)
        {
            var srcProps = src.GetType().GetProperties();
            var objProps = obj.GetType().GetProperties();

            foreach (var srcProp in srcProps)
            {
                foreach (var objProp in objProps)
                {
                    if (!copyId)
                    {
                        if (srcProp.Name == "Id" && srcProp.PropertyType == typeof(int))
                        {
                            break;
                        }
                    }

                    if (srcProp.Name == objProp.Name && srcProp.PropertyType == objProp.PropertyType)
                    {
                        if (objProp.GetValue(obj) != null)
                        {
                            srcProp.SetValue(src, objProp.GetValue(obj));
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Includes all includable properties from a DbSet object.
        /// </summary>
        /// <typeparam name="T">The Data Model/Table of the DbSet object</typeparam>
        /// <param name="dbSet">DbSet object</param>
        /// <returns>IQueryable of the DbSet object with included properties</returns>
        public static IQueryable<T> IncludePropsToDbSet<T>(this DbSet<T> dbSet)
            where T : class, BaseDataModel
        {
            var dbSetIncluded = dbSet.AsQueryable();

            var includablePropPaths = Helper.DetermineIncludablePropPaths(
                typeof(T),
                null,
                new List<string>(),
                new List<string>());

            foreach (var propPath in includablePropPaths)
            {
                dbSetIncluded = dbSetIncluded.Include(propPath);
            }

            return dbSetIncluded;
        }

        /// <summary>
        ///     Note: This function is recursive. Determines the paths of all includable properties from a DbSet object. 
        /// </summary>
        /// <param name="item">The type of the current includable property</param>
        /// <param name="parentItemPath">The path of the parent item that the current property is a property of</param>
        /// <param name="includedProps">List of already included properties</param>
        /// <param name="includedPropPaths">List of already determined paths</param>
        /// <returns>ICollection of paths of all includable properties</returns>
        public static ICollection<string> DetermineIncludablePropPaths(Type item, string parentItemPath, ICollection<string> includedProps, ICollection<string> includedPropPaths)
        {
            var includableProps = item.GetIncludableProps();

            foreach (var prop in includableProps)
            {
                var propType = prop.PropertyType;

                if (typeof(IEnumerable).IsAssignableFrom(propType))
                {
                    var collectionPath = parentItemPath == null || parentItemPath == "" ?
                        prop.Name :
                        parentItemPath + "." + prop.Name;

                    if (!includedPropPaths.Contains(collectionPath))
                    {
                        includedPropPaths.Add(collectionPath);
                    }
                }
                else
                {
                    if (!includedProps.Contains(propType.Name))
                    {
                        includedProps.Add(propType.Name);

                        var itemPath = parentItemPath == null || parentItemPath == "" ?
                            prop.Name :
                            parentItemPath + "." + prop.Name;

                        includedPropPaths.Add(itemPath);

                        // Recursive function
                        DetermineIncludablePropPaths(propType, itemPath, includedProps, includedPropPaths);
                    }
                }
            }

            return includedPropPaths;
        }

        /// <summary>
        ///     Determines all includable properties from a DbSet object.
        /// </summary>
        /// <param name="obj">Type of object the cointains includable properties.</param>
        /// <param name="includeCollections">Bool that inducates whether collections should be included.</param>
        /// <param name="includeBaseModels">Bool that inducates whether Data Models should be included.</param>
        /// <returns>ICollection of PropertyInfo objects that are includable properties</returns>
        public static IEnumerable<PropertyInfo> GetIncludableProps(this Type obj, bool includeCollections = true, bool includeBaseModels = true)
        {
            var props = obj.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (includeCollections && includeBaseModels)
            {
                return props.Where(p =>
                    typeof(BaseDataModel).IsAssignableFrom(p.PropertyType) ||
                    typeof(IEnumerable<BaseDataModel>).IsAssignableFrom(p.PropertyType));
            }

            if (includeCollections && !includeBaseModels)
            {
                return props.Where(p => typeof(IEnumerable<BaseDataModel>).IsAssignableFrom(p.PropertyType));
            }

            if (!includeCollections && includeBaseModels)
            {
                return props.Where(p => typeof(BaseDataModel).IsAssignableFrom(p.PropertyType));
            }

            throw new WebException("You must include eather 'BaseModels' or 'Collections' or both");
        }
    }
}
