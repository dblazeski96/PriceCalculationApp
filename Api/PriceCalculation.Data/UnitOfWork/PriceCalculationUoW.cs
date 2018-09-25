using PriceCalculation.Data.Repository;
using PriceCalculation.Data.Factory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.UnitOfWork
{
    public class PriceCalculationUoW<Context> : BaseUoW<Context>, IPriceCalculationUoW where Context : DbContext
    {
        public IBusinessItemRepository _businessItemRepository { get; private set; }

        public PriceCalculationUoW()
        {
            _businessItemRepository = RepositoryFactory.Create<IBusinessItemRepository>(_dbContext);
        }
    }
}
