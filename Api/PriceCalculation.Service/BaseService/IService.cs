using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Service
{
    public interface IService
    {
        ServiceResult<TOutput> Create<TInput, TOutput>(TInput item) 
            where TInput : class, BaseViewModel where TOutput : class, BaseViewModel;

        ServiceResult<TOutput> Change<TInput, TOutput>(TInput item) 
            where TInput : class, BaseViewModel where TOutput : class, BaseViewModel;

        ServiceResult<TOutput> Remove<TOutput>(int id) 
            where TOutput : class, BaseViewModel;

        ServiceResult<TOutput> Get<TOutput>(int id) 
            where TOutput : class, BaseViewModel;

        ServiceResult<TOutput> GetAll<TOutput>(string property, string searchCriteria) 
            where TOutput : class, BaseViewModel;
    }
}
