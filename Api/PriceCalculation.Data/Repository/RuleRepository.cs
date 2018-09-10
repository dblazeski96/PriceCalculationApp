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
        public RuleRepository(PriceCalculationContext dbContext) : base(dbContext)
        {
        }

        public void Create(Rule item)
        {
            _dbContext.Rules.Add(item);
        }

        public async Task Change(Rule item)
        {
            var ruleToChange = await _dbContext.Rules.SingleAsync(r => r.Id == item.Id);
            ruleToChange.Name = item.Name;
            ruleToChange.Equation1 = item.Equation1;
            ruleToChange.Equation2 = item.Equation2;
            ruleToChange.Operation = item.Operation;
        }

        public async Task Remove(int id)
        {
            var ruleToRemove = await _dbContext.Rules.SingleAsync(r => r.Id == id);
            _dbContext.Rules.Remove(ruleToRemove);
        }

        public async Task<Rule> Get(int id)
        {
            return await _dbContext.Rules.SingleAsync(r => r.Id == id);
        }

        public async Task<IList<Rule>> GetAll()
        {
            return await _dbContext.Rules.Include(r => r.Strategies).ToListAsync();
        }
    }
}
