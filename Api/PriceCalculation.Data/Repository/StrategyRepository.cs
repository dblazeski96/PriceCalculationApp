using PriceCalculation.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class StrategyRepository : PriceCalculationRepository, IRepository<Strategy>
    {
        public StrategyRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
        {
        }

        public void Create(Strategy item)
        {
            _priceCalculationContext.Strategies.Add(item);
        }

        public async Task Change(Strategy item)
        {
            var strategyToChange = await _priceCalculationContext.Strategies.SingleAsync(s => s.Id == item.Id);
            strategyToChange.Name = item.Name;
        }

        public async Task Remove(int id)
        {
            var strategyToRemove = await _priceCalculationContext.Strategies.SingleAsync(s => s.Id == id);
            _priceCalculationContext.Strategies.Remove(strategyToRemove);
        }

        public async Task<Strategy> Get(int id)
        {
            return await _priceCalculationContext.Strategies.Include(s => s.Operations).Include(s => s.Rules).SingleAsync(s => s.Id == id); ;
        }

        public async Task<IList<Strategy>> GetAll()
        {
            return await _priceCalculationContext.Strategies.Include(s => s.Operations).Include(s => s.Rules).ToListAsync();
        }
    }
}
