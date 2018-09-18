using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.Factory;
using System.Data.Entity;

namespace PriceCalculation.Data.UnitOfWork
{
    public class SearchUoW : ISearchUoW
    {
        private readonly DbContext _priceCalculationContext = ContextFactory<PriceCalculationContext>.Create();

        public IBusinessItemRepository _businessItemRepository
        {
            get
            {
                return RepositoryFactory<BusinessItemRepository>.Create(_priceCalculationContext);
            }
        }

        public void Commit()
        {
            _priceCalculationContext.SaveChanges();
        }

        public void Dispose()
        {
            _priceCalculationContext.Dispose();
        }
    }
}
