using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class BusinessItemRepository : BaseRepository, IRepository<BusinessItem>
    {
        public void Create(BusinessItem item)
        {
            DbContext.BusinessItems.Add(item);
        }

        public async Task Change(BusinessItem item)
        {
            var itemToChange = await DbContext.Items.SingleAsync(i => i.Id == item.ItemId);
            itemToChange.Name = item.Item.Name;
            itemToChange.Description = item.Item.Description;
            itemToChange.GroupId = item.Item.GroupId;

            var bItemToChange = await DbContext.BusinessItems
                                                .Include(i => i.Prices)
                                                .SingleAsync(i => i.Id == item.Id);

            bItemToChange.Quantity = item.Quantity;
            bItemToChange.DateOfProduction = item.DateOfProduction;
            bItemToChange.DateOfLastSold = item.DateOfLastSold;
            bItemToChange.Prices.Single(p => p.Type == PriceType.Cost).Amount = item.Prices.Single(p => p.Type == PriceType.Cost).Amount;
            bItemToChange.Prices.Single(p => p.Type == PriceType.Target).Amount = item.Prices.Single(p => p.Type == PriceType.Target).Amount;
            bItemToChange.Prices.Single(p => p.Type == PriceType.Premium).Amount = item.Prices.Single(p => p.Type == PriceType.Premium).Amount;
        }

        public async Task Remove(int id)
        {
            var itemToRemove = await DbContext.BusinessItems.SingleAsync(i => i.Id == id);
            DbContext.BusinessItems.Remove(itemToRemove);
        }

        public async Task<BusinessItem> Get(int id)
        {
            return await DbContext.BusinessItems
                                    .Include(i => i.Item)
                                    .Include(i => i.Item.Group)
                                    .Include(i => i.Prices)
                                    .Include(i => i.Catalogues)
                                    .SingleAsync(i => i.Id == id);
        }

        public async Task<IList<BusinessItem>> GetAll()
        {
            return await DbContext.BusinessItems
                                    .Include(i => i.Item)
                                    .Include(i => i.Item.Group)
                                    .Include(i => i.Prices)
                                    .Include(i => i.Catalogues)
                                    .ToListAsync();
        }
    }
}
