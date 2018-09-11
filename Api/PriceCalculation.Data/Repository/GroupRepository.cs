using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class GroupRepository : PriceCalculationRepository, IGroupRepository
    {
        public GroupRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
        {
        }

        public void Create(Group item)
        {
            _priceCalculationContext.Groups.Add(item);
        }

        public async Task Change(Group item)
        {
            var groupToChange = await _priceCalculationContext.Groups
                                                .SingleAsync(g => g.Id == item.Id);
            groupToChange.Name = item.Name;
            groupToChange.StrategyId = item.StrategyId;
        }

        public async Task Remove(int id)
        {
            var groupToRemove = await _priceCalculationContext.Groups
                                                .SingleAsync(g => g.Id == id);
            _priceCalculationContext.Groups.Remove(groupToRemove);
        }

        public async Task<Group> Get(int id)
        {
            return await _priceCalculationContext.Groups
                                    .SingleAsync(g => g.Id == id);
        }

        public async Task<IList<Group>> GetAll()
        {
            return await _priceCalculationContext.Groups
                                    .Include(g => g.Items)
                                    .ToListAsync();
        }


    }
}
