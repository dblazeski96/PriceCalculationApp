using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using PriceCalculation.Service.Models;

namespace PriceCalculation.Service
{
    public interface IBusinessItemService : IService<BusinessItemViewModel, BusinessItem>
    {
    }
}
