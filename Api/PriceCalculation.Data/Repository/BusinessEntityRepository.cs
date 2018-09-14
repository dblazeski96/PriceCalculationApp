using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    //public class BusinessEntityRepository : BaseRepository, IBusinessEntityRepository
    //{
    //    public BusinessEntityRepository(PriceCalculationContext priceCalculationContext) : base(priceCalculationContext)
    //    {
    //    }

    //    public void Create(BusinessEntity item)
    //    {
    //        _priceCalculationContext.BusinessEntities.Add(item);
    //    }

    //    public void Change(BusinessEntity item)
    //    {
    //        var businessEntityToChange = _priceCalculationContext.BusinessEntities.Single(b => b.Id == item.Id);
    //        businessEntityToChange.Name = item.Name;
    //        businessEntityToChange.Type = item.Type;
    //        businessEntityToChange.Currency = item.Currency;
    //    }

    //    public void Remove(int id)
    //    {
    //        var businessEntityToRemove = _priceCalculationContext.BusinessEntities.Single(b => b.Id == id);
    //        _priceCalculationContext.BusinessEntities.Remove(businessEntityToRemove);
    //    }

    //    public BusinessEntity Get(int id)
    //    {
    //        return _priceCalculationContext.BusinessEntities.Single(b => b.Id == id);
    //    }

    //    public IList<BusinessEntity> GetAll()
    //    {
    //        return _priceCalculationContext.BusinessEntities.Include(b => b.Catalogues).ToList();
    //    }
    //}
}
