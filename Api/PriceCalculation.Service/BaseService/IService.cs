using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public interface IService<TViewModel, T>
    {
        ServiceResult<TViewModel> Create(T item);
        ServiceResult<TViewModel> Change(T item);
        ServiceResult<TViewModel> Remove(int id);
        ServiceResult<TViewModel> Get(int id);
        ServiceResult<TViewModel> GetAll();
    }
}
