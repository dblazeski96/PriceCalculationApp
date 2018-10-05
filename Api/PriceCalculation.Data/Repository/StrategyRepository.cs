using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Data;

namespace PriceCalculation.Data.Repository
{
    public class StrategyRepository : BaseRepository<Strategy>, IStrategyRepository
    {
        public StrategyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
