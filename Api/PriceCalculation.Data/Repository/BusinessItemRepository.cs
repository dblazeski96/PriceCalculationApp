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
        public BusinessItemRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext) { }

        public void Create(BusinessItem item)
        {
            if (item.ItemId == null)
            {
                _priceCalculationContext.Items.Add(item.Item);
                item.ItemId = _priceCalculationContext.Items.Local.Last().Id;
            }

            _priceCalculationContext.BusinessItems.Add(item);
        }

        public void Change(BusinessItem item)
        {
            var itemToChange = _priceCalculationContext.Items.Single(i => i.Id == item.ItemId);
            itemToChange.Name = item.Item.Name;
            itemToChange.Description = item.Item.Description;
            itemToChange.GroupId = item.Item.GroupId;

            var businessItemToChange = _priceCalculationContext.BusinessItems
                                                .Include(i => i.Prices)
                                                .Single(i => i.Id == item.Id);

            businessItemToChange.Quantity = item.Quantity;
            businessItemToChange.DateOfProduction = item.DateOfProduction;
            businessItemToChange.DateOfLastSold = item.DateOfLastSold;
            businessItemToChange.Prices.Single(p => p.Type == PriceType.Cost).Amount = item.Prices.Single(p => p.Type == PriceType.Cost).Amount;
            businessItemToChange.Prices.Single(p => p.Type == PriceType.Target).Amount = item.Prices.Single(p => p.Type == PriceType.Target).Amount;
            businessItemToChange.Prices.Single(p => p.Type == PriceType.Premium).Amount = item.Prices.Single(p => p.Type == PriceType.Premium).Amount;
        }

        public void Remove(int id)
        {
            var businessItemToRemove = _priceCalculationContext.BusinessItems.Single(i => i.Id == id);

            _priceCalculationContext.BusinessItems.Remove(businessItemToRemove);
        }

        public BusinessItem Get(int id)
        {
            return _priceCalculationContext.BusinessItems
                                    .Include(i => i.Item)
                                    .Include(i => i.Item.Group)
                                    .Include(i => i.Prices)
                                    .Include(i => i.Catalogues)
                                    .Single(i => i.Id == id);
        }

        public IList<BusinessItem> GetAll()
        {
            return _priceCalculationContext.BusinessItems
                                    .Include(i => i.Item)
                                    .Include(i => i.Item.Group)
                                    .Include(i => i.Prices)
                                    .Include(i => i.Catalogues)
                                    .ToList();
        }
    }
}
