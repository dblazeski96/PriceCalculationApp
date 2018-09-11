using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.Factory;

namespace PriceCalculation.Data.UnitOfWork
{
    public class SearchUoW : ISearchUoW
    {
        private IPriceCalculationContextFactory _priceCalculationContextFactory;
        private IBusinessItemFactory _businessItemFactory;
        private PriceCalculationContext _priceCalculationContext;
        public SearchUoW(IPriceCalculationContextFactory priceCalculationContextFactory, IBusinessItemFactory businessItemFactory)
        {
            _priceCalculationContextFactory = priceCalculationContextFactory;
            _businessItemFactory = businessItemFactory;
            //_priceCalculationContext = (PriceCalculationContext)_priceCalculationContextFactory.Create();
            _priceCalculationContext = new PriceCalculationContext();
        }

        public IBusinessItemRepository _businessItemRepository
        {
            get
            {
                //return (IBusinessItemRepository)_businessItemFactory.Create(_priceCalculationContext);
                return new BusinessItemRepository(_priceCalculationContext);
            }
        }

        public async Task Commit()
        {
           await _priceCalculationContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _priceCalculationContext.Dispose();
        }
    }
}
