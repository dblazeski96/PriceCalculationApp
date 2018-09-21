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
        ServiceResult<TViewModel> ChangePropertyOfMultipleItems<TViewModel, T>(string property, string value, List<int> items) 
            where T : class
            where TViewModel : class;
    }
}
