using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.UnitOfWork
{
    public class BaseUnitOfWork : IDisposable
    {
        protected readonly PriceCalculationContext _dbContext;

        public BaseUnitOfWork()
        {
            _dbContext = new PriceCalculationContext();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
