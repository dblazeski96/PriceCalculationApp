using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Mapper
{
    public static class DbSetMapper
    {
        public static void CopyProperties(this object dbSet, object obj)
        {
            var dbSetProps = dbSet.GetType().GetProperties();
            var objProps = obj.GetType().GetProperties();

            foreach(var dbSetProp in dbSetProps)
            {
                foreach(var objProp in objProps)
                {
                    if(dbSetProp.Name == objProp.Name && dbSetProp.PropertyType == objProp.PropertyType)
                    {
                        dbSetProp.SetValue(dbSet, objProp.GetValue(obj));
                    }
                }
            }
        }
    }
}
