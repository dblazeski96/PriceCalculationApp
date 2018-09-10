using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;

namespace PriceCalculation.Data.UnitOfWork
{
    public class SearchUoW : BaseUnitOfWork, ISearchUoW
    {
        IBusinessItemRepository ISearchUoW._businessItemRepository
        {
            get
            {
                return new BusinessItemRepository(_dbContext);
            }
        }
    }
}
