using PriceCalculation.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PriceCalculation.Mapper
{
    public static class Helper
    {
        public static void CopyPropertiesFrom(this object src, object obj, bool copyId = true)
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

        public static IEnumerable<PropertyInfo> GetIncludableProps(this Type obj, bool includeCollections = true, bool includeBaseModels = true)
        {
            var props = obj.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (includeCollections && includeBaseModels)
            {
                return props.Where(p =>
                    typeof(BaseModel).IsAssignableFrom(p.PropertyType) ||
                    typeof(IEnumerable<BaseModel>).IsAssignableFrom(p.PropertyType));
            }

            if (includeCollections && !includeBaseModels)
            {
                return props.Where(p => typeof(IEnumerable).IsAssignableFrom(p.PropertyType));
            }

            if (!includeCollections && includeBaseModels)
            {
                return props.Where(p => typeof(BaseModel).IsAssignableFrom(p.PropertyType));
            }

            throw new WebException("You must include eather 'BaseModels' or 'Collections' or both");
        }
    }
}
