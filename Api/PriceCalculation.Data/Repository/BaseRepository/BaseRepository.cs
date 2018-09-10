using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class BaseRepository
    {
        protected readonly PriceCalculationContext _dbContext;

        public BaseRepository(PriceCalculationContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
