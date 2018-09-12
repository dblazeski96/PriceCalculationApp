using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class RuleRepository : BaseRepository, IRuleRepository
    {
        public RuleRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
        {
        }

        public void Create(Rule item)
        {
            _priceCalculationContext.Rules.Add(item);
        }

        public void Change(Rule item)
        {
            var ruleToChange = _priceCalculationContext.Rules.Single(r => r.Id == item.Id);
            ruleToChange.Name = item.Name;
            ruleToChange.Equation1 = item.Equation1;
            ruleToChange.Equation2 = item.Equation2;
            ruleToChange.Operation = item.Operation;
        }

        public void Remove(int id)
        {
            var ruleToRemove = _priceCalculationContext.Rules.Single(r => r.Id == id);
            _priceCalculationContext.Rules.Remove(ruleToRemove);
        }

        public Rule Get(int id)
        {
            return _priceCalculationContext.Rules.Single(r => r.Id == id);
        }

        public IList<Rule> GetAll()
        {
            return _priceCalculationContext.Rules.Include(r => r.Strategies).ToList();
        }
    }
}
