using PriceCalculation.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class StrategyRepository : BaseRepository<Strategy>, IStrategyRepository
    {
        public StrategyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
