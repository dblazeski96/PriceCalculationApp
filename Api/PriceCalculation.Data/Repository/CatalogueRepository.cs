using PriceCalculation.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    //public class CatalogueRepository : BaseRepository, IRepository<Catalogue>
    //{
    //    public CatalogueRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
    //    {
    //    }

    //    public void Create(Catalogue item)
    //    {
    //        _priceCalculationContext.Catalogues.Add(item);
    //    }

    //    public void Change(Catalogue item)
    //    {
    //        var catalogueToChange = _priceCalculationContext.Catalogues.Single(c => c.Id == item.Id);
    //        catalogueToChange.Name = item.Name;
    //        catalogueToChange.BusinessEntityId = item.Id;
    //    }

    //    public void Remove(int id)
    //    {
    //        var catalogueToRemove = _priceCalculationContext.Catalogues.Single(c => c.Id == id);
    //        _priceCalculationContext.Catalogues.Remove(catalogueToRemove);
    //    }

    //    public Catalogue Get(int id)
    //    {
    //        return _priceCalculationContext.Catalogues.Single(c => c.Id == id);
    //    }

    //    public IList<Catalogue> GetAll()
    //    {
    //        return _priceCalculationContext.Catalogues.Include(c => c.CatalogueItems).ToList();
    //    }
    //}
}
