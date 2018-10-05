using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PriceCalculation.Models.Data;

namespace PriceCalculation.Data.Repository
{
    public class BusinessItemRepository : BaseRepository<BusinessItem>, IBusinessItemRepository
    {
        public BusinessItemRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void ChangePropertyOfMultipleItems(string property, string value, List<int> items)
        {

        }
    }
}
