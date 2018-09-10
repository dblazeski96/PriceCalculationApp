using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class BusinessItemRepository : BaseRepository, IBusinessItemRepository
    {
        public BusinessItemRepository(PriceCalculationContext dbContext) : base(dbContext) { }

        public void Create(BusinessItem item)
        {
            if (item.ItemId == null)
            {
                _dbContext.Items.Add(item.Item);
                item.ItemId = _dbContext.Items.Local.Last().Id;
            }

            _dbContext.BusinessItems.Add(item);
        }

        public async Task Change(BusinessItem item)
        {
            var itemToChange = await _dbContext.Items.SingleAsync(i => i.Id == item.ItemId);
            itemToChange.Name = item.Item.Name;
            itemToChange.Description = item.Item.Description;
            itemToChange.GroupId = item.Item.GroupId;

            var businessItemToChange = await _dbContext.BusinessItems
                                                .Include(i => i.Prices)
                                                .SingleAsync(i => i.Id == item.Id);

            businessItemToChange.Quantity = item.Quantity;
            businessItemToChange.DateOfProduction = item.DateOfProduction;
            businessItemToChange.DateOfLastSold = item.DateOfLastSold;
            businessItemToChange.Prices.Single(p => p.Type == PriceType.Cost).Amount = item.Prices.Single(p => p.Type == PriceType.Cost).Amount;
            businessItemToChange.Prices.Single(p => p.Type == PriceType.Target).Amount = item.Prices.Single(p => p.Type == PriceType.Target).Amount;
            businessItemToChange.Prices.Single(p => p.Type == PriceType.Premium).Amount = item.Prices.Single(p => p.Type == PriceType.Premium).Amount;
        }

        public async Task Remove(int id)
        {
            var businessItemToRemove = await _dbContext.BusinessItems.SingleAsync(i => i.Id == id);

            _dbContext.BusinessItems.Remove(businessItemToRemove);
        }

        public async Task<BusinessItem> Get(int id)
        {
            return await _dbContext.BusinessItems
                                    .Include(i => i.Item)
                                    .Include(i => i.Item.Group)
                                    .Include(i => i.Prices)
                                    .Include(i => i.Catalogues)
                                    .SingleAsync(i => i.Id == id);
        }

        public async Task<IList<BusinessItem>> GetAll()
        {
            return await _dbContext.BusinessItems
                                    .Include(i => i.Item)
                                    .Include(i => i.Item.Group)
                                    .Include(i => i.Prices)
                                    .Include(i => i.Catalogues)
                                    .ToListAsync();
        }
    }
}
