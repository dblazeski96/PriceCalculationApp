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
    public class SearchUoW : BaseUoW
    {
        public SearchUoW(DbContext[] dbContexts) : base(dbContexts)
        {
        }
        public SearchUoW(DbContext dbContext) : base(dbContext)
        {
        }

        public IBusinessItemRepository _businessItemRepository
        {
            get
            {
                return RepositoryFactory<BusinessItemRepository>.Create(_dbContexts[typeof(PriceCalculationContext)]);
            }
        }

        //public void Commit()
        //{
        //   _priceCalculationContext.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    _priceCalculationContext.Dispose();
        //}
    }
}
