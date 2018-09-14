using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;
using PriceCalculation.Mapper;

namespace PriceCalculation.Data.Repository
{
    public class BusinessItemRepository : BaseRepository<PriceCalculationContext, BusinessItem>, IBusinessItemRepository
    {
        public BusinessItemRepository(PriceCalculationContext dbContext) : base(dbContext)
        {
        }


    }
}
