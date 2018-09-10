using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class GroupRepository : BaseRepository, IGroupRepository
    {
        public GroupRepository(PriceCalculationContext dbContext) : base(dbContext)
        {
        }

        public void Create(Group item)
        {
            _dbContext.Groups.Add(item);
        }

        public async Task Change(Group item)
        {
            var groupToChange = await _dbContext.Groups
                                                .SingleAsync(g => g.Id == item.Id);
            groupToChange.Name = item.Name;
            groupToChange.StrategyId = item.StrategyId;
        }

        public async Task Remove(int id)
        {
            var groupToRemove = await _dbContext.Groups
                                                .SingleAsync(g => g.Id == id);
            _dbContext.Groups.Remove(groupToRemove);
        }

        public async Task<Group> Get(int id)
        {
            return await _dbContext.Groups
                                    .SingleAsync(g => g.Id == id);
        }

        public async Task<IList<Group>> GetAll()
        {
            return await _dbContext.Groups
                                    .Include(g => g.Items)
                                    .ToListAsync();
        }


    }
}
