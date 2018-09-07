using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public interface IRepository<T> : IBaseRepository
    {
        void Create(T item);
        Task Change(T item);
        Task Remove(int id);
        Task<T> Get(int id);
        Task<IList<T>> GetAll();
    }
}
