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
    public class PriceCalculationUoW<Context> : BaseUoW<Context>, IPriceCalculationUoW 
        where Context : DbContext
    {
        public IBusinessEntityRepository _businessEntityRepository { get; private set; }
        public IBusinessItemRepository _businessItemRepository { get; private set; }
        public ICatalogueRepository _catalogueRepository { get; private set; }
        public IGroupRepository _groupRepository { get; private set; }
        public IRuleRepository _ruleRepository { get; private set; }
        public IStrategyRepository _strategyRepository { get; private set; }

        public PriceCalculationUoW()
        {
            _businessEntityRepository = RepositoryFactory.Create<IBusinessEntityRepository>(_dbContext);
            _businessItemRepository = RepositoryFactory.Create<IBusinessItemRepository>(_dbContext);
            _catalogueRepository = RepositoryFactory.Create<ICatalogueRepository>(_dbContext);
            _groupRepository = RepositoryFactory.Create<IGroupRepository>(_dbContext);
            _ruleRepository = RepositoryFactory.Create<IRuleRepository>(_dbContext);
            _strategyRepository = RepositoryFactory.Create<IStrategyRepository>(_dbContext);
        }
    }
}
