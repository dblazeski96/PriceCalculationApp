using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Data;

namespace PriceCalculation.Data.Repository
{
    public interface IBusinessItemRepository : IRepository<BusinessItem>
    {
        void ChangePropertyOfMultipleItems(string property, string value, List<int> items);
    }
}
