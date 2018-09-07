using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly PriceCalculationContext _dbContext;

        public BaseRepository()
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
