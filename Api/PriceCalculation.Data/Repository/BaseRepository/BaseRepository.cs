using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        protected PriceCalculationContext DbContext;

        public BaseRepository()
        {
            DbContext = new PriceCalculationContext();
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
