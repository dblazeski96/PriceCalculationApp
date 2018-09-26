using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public interface ISearchService : IService, IDisposable
    {
        ServiceResult<TOutput> ChangePropertyOfMultipleItems<TOutput>(string property, string value, List<int> items) 
            where TOutput : class;
    }
}
