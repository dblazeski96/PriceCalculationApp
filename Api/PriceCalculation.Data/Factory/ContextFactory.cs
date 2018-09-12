using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Factory
{
    public static class ContextFactory<T> where T : DbContext
    {
        public static T Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
