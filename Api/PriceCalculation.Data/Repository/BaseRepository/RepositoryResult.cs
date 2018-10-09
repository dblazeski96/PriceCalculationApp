using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Data.Repository
{
    public class RepositoryResult<T>
        where T : class, BaseDataModel
    {
        public bool Success { get; set; }
        public Exception ex { get; set; }
        public T item { get; set; }
        public IEnumerable<T> items { get; set; }
    }
}
