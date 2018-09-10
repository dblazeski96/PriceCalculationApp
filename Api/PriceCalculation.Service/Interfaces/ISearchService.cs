using PriceCalculation.Data.Models;
using PriceCalculation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public interface ISearchService : IService<BusinessItemViewModel, BusinessItem>, IDisposable
    {

    }
}
