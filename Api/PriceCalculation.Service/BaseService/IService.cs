using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public interface IService
    {
        ServiceResult<TOutput> Create<TInput, TOutput>(TInput item) where TInput : class where TOutput : class;
        ServiceResult<TOutput> Change<TInput, TOutput>(TInput item) where TInput : class where TOutput : class;
        ServiceResult<TOutput> Remove<TOutput>(int id) where TOutput : class;
        ServiceResult<TOutput> Get<TOutput>(int id) where TOutput : class;
        ServiceResult<TOutput> GetAll<TOutput>() where TOutput : class;
    }
}
