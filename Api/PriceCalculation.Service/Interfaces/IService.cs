using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public interface IService<TViewModel, T> : IDisposable
    {
        Task<ServiceResult<TViewModel>> Create(T item);
        Task<ServiceResult<TViewModel>> Change(T item);
        Task<ServiceResult<TViewModel>> Remove(int id);
        Task<ServiceResult<TViewModel>> Get(int id);
        Task<ServiceResult<TViewModel>> GetAll();
    }
}
