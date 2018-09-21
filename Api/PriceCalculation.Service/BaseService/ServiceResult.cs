using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public Exception ex { get; set; }
        public T Item { get; set; }
        public IList<T> Items { get; set; }
    }
}
