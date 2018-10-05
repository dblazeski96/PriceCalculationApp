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
        // Copy Properties from one object to another
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

        // Includes all includable properties from a DbSet object.
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

        // Extension for "IncludePropsToDbSet" method. Gets the paths of the includable properties for the current DbSet object.
        private static ICollection<string> DetermineIncludablePropPaths(Type item, string parentItemPath, ICollection<string> includedProps, ICollection<string> includedPropPaths)
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

        // Extension for "IncludePropsToDbSet" method. Gets all the includable properties for the current DbSet object.
        private static IEnumerable<PropertyInfo> GetIncludableProps(this Type obj, bool includeCollections = true, bool includeBaseModels = true)
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
