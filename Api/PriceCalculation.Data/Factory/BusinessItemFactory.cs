using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;
using System.Data.Entity;

namespace PriceCalculation.Data.Factory
{
    public class BusinessItemFactory : RepositoryFactory, IBusinessItemFactory
    {
        public override PriceCalculationRepository Create(DbContext dbContext)
        {
            return new BusinessItemRepository((PriceCalculationContext)dbContext);
        }
    }
}
