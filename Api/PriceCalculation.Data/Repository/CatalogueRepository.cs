using PriceCalculation.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class CatalogueRepository : PriceCalculationRepository, IRepository<Catalogue>
    {
        public CatalogueRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
        {
        }

        public void Create(Catalogue item)
        {
            _priceCalculationContext.Catalogues.Add(item);
        }

        public async Task Change(Catalogue item)
        {
            var catalogueToChange = await _priceCalculationContext.Catalogues.SingleAsync(c => c.Id == item.Id);
            catalogueToChange.Name = item.Name;
            catalogueToChange.BusinessEntityId = item.Id;
        }

        public async Task Remove(int id)
        {
            var catalogueToRemove = await _priceCalculationContext.Catalogues.SingleAsync(c => c.Id == id);
            _priceCalculationContext.Catalogues.Remove(catalogueToRemove);
        }

        public async Task<Catalogue> Get(int id)
        {
            return await _priceCalculationContext.Catalogues.SingleAsync(c => c.Id == id);
        }

        public async Task<IList<Catalogue>> GetAll()
        {
            return await _priceCalculationContext.Catalogues.Include(c => c.CatalogueItems).ToListAsync();
        }
    }
}
