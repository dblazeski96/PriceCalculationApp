using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class BusinessEntityRepository : BaseRepository<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityRepository(DbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
