using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PriceCalculation.Models.Data;

namespace PriceCalculation.Data.Repository
{
    public class BusinessEntityRepository : BaseRepository<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityRepository(DbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
