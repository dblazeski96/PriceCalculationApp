using PriceCalculation.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Mapper
{
    public static class Helper
    {
        public static void CopyPropertiesFrom(this object src, object obj)
        {
            PropertyInfo[] srcProps = src.GetType().GetProperties();
            PropertyInfo[] objProps = obj.GetType().GetProperties();

            foreach(PropertyInfo srcProp in srcProps)
            {
                foreach(PropertyInfo objProp in objProps)
                {
                    if(srcProp.Name == objProp.Name && srcProp.PropertyType == objProp.PropertyType)
                    {
                        srcProp.SetValue(src, objProp.GetValue(obj));
                    }
                }
            }
        }

        public static IEnumerable<PropertyInfo> GetIncludableProps(this IEnumerable<PropertyInfo> props)
        {
            return props.Where(prop => typeof(BaseModel).IsAssignableFrom(prop.PropertyType) || typeof(IList).IsAssignableFrom(prop.PropertyType));
        }

        public static Type GetDataModelType<TOutput>()
        {
            var viewType = typeof(TOutput);

            string dataTypeName = viewType.Name.Replace("OModel", "");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var models = assembly.GetTypes().Where(m => m.Name == dataTypeName);
                if (models.Any())
                {
                    return models.FirstOrDefault();
                }
            }

            throw new Exception("Data model not found!");
        }
    }
}
