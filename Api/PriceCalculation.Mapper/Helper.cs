using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Mapper
{
    public static class Helper
    {
        public static void CopyProperties(this object src, object obj)
        {
            var srcProps = src.GetType().GetProperties();
            var objProps = obj.GetType().GetProperties();

            foreach(var srcProp in srcProps)
            {
                foreach(var objProp in objProps)
                {
                    if(srcProp.Name == objProp.Name && srcProp.PropertyType == objProp.PropertyType)
                    {
                        srcProp.SetValue(src, objProp.GetValue(obj));
                    }
                }
            }
        }
    }
}
