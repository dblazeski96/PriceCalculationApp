using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Data.Repository
{
    public interface IRepository<T>
    {
        void Create(T item);

        void Change(T item);

        void Remove(int id);

        T Get(int id);

        IEnumerable<T> GetAll(string property, string searchCriteria);
    }
}
