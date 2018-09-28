using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Change(T item);
        void Remove(int id);
        T Get(int id);
        IList<T> GetAll(string property, string searchCriteria);
    }
}
