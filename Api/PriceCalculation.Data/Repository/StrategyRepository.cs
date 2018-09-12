using PriceCalculation.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class StrategyRepository : BaseRepository, IRepository<Strategy>
    {
        public StrategyRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
        {
        }

        public void Create(Strategy item)
        {
            _priceCalculationContext.Strategies.Add(item);
        }

        public void Change(Strategy item)
        {
            var strategyToChange = _priceCalculationContext.Strategies.Single(s => s.Id == item.Id);
            strategyToChange.Name = item.Name;
        }

        public void Remove(int id)
        {
            var strategyToRemove = _priceCalculationContext.Strategies.Single(s => s.Id == id);
            _priceCalculationContext.Strategies.Remove(strategyToRemove);
        }

        public Strategy Get(int id)
        {
            return _priceCalculationContext.Strategies.Include(s => s.Operations).Include(s => s.Rules).Single(s => s.Id == id); ;
        }

        public IList<Strategy> GetAll()
        {
            return _priceCalculationContext.Strategies.Include(s => s.Operations).Include(s => s.Rules).ToList();
        }
    }
}
