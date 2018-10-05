using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Service
{
    public interface ISearchService : IService, IDisposable
    {
        ServiceResult<TOutput> ChangePropertyOfMultipleItems<TOutput>(string property, string value, IList<int> items) 
            where TOutput : class, BaseViewModel;
    }
}
