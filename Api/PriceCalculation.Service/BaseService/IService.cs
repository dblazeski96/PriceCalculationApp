using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public interface IService
    {
        ServiceResult<TViewModel> Create<TViewModel, T>(T item) where T : class where TViewModel : class;
        ServiceResult<TViewModel> Change<TViewModel, T>(T item) where T : class where TViewModel : class;
        ServiceResult<TViewModel> Remove<TViewModel, T>(int id) where T : class where TViewModel : class;
        ServiceResult<TViewModel> Get<TViewModel, T>(int id) where T : class where TViewModel : class;
        ServiceResult<TViewModel> GetAll<TViewModel, T>() where T : class where TViewModel : class;
    }
}
