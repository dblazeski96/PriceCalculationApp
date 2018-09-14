using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    //public class GroupRepository : BaseRepository, IGroupRepository
    //{
    //    public GroupRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
    //    {
    //    }

    //    public void Create(Group item)
    //    {
    //        _priceCalculationContext.Groups.Add(item);
    //    }

    //    public void Change(Group item)
    //    {
    //        var groupToChange = _priceCalculationContext.Groups
    //                                            .Single(g => g.Id == item.Id);
    //        groupToChange.Name = item.Name;
    //        groupToChange.StrategyId = item.StrategyId;
    //    }

    //    public void Remove(int id)
    //    {
    //        var groupToRemove = _priceCalculationContext.Groups
    //                                            .Single(g => g.Id == id);
    //        _priceCalculationContext.Groups.Remove(groupToRemove);
    //    }

    //    public Group Get(int id)
    //    {
    //        return _priceCalculationContext.Groups
    //                                .Single(g => g.Id == id);
    //    }

    //    public IList<Group> GetAll()
    //    {
    //        return _priceCalculationContext.Groups
    //                                .Include(g => g.Items)
    //                                .ToList();
    //    }


    //}
}
