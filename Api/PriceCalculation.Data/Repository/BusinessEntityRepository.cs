using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class BusinessEntityRepository : PriceCalculationRepository, IBusinessEntityRepository
    {
        public BusinessEntityRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
        {
        }

        public void Create(BusinessEntity item)
        {
            _priceCalculationContext.BusinessEntities.Add(item);
        }

        public async Task Change(BusinessEntity item)
        {
            var businessEntityToChange = await _priceCalculationContext.BusinessEntities.SingleAsync(b => b.Id == item.Id);
            businessEntityToChange.Name = item.Name;
            businessEntityToChange.Type = item.Type;
            businessEntityToChange.Currency = item.Currency;
        }

        public async Task Remove(int id)
        {
            var businessEntityToRemove = await _priceCalculationContext.BusinessEntities.SingleAsync(b => b.Id == id);
            _priceCalculationContext.BusinessEntities.Remove(businessEntityToRemove);
        }

        public async Task<BusinessEntity> Get(int id)
        {
            return await _priceCalculationContext.BusinessEntities.SingleAsync(b => b.Id == id);
        }

        public async Task<IList<BusinessEntity>> GetAll()
        {
            return await _priceCalculationContext.BusinessEntities.Include(b => b.Catalogues).ToListAsync();
        }
    }
}
