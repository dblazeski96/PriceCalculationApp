using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Repository
{
    public class PriceCalculationRepository
    {
        protected readonly PriceCalculationContext _priceCalculationContext;
        public PriceCalculationRepository(PriceCalculationContext priceCalculationContext)
        {
            _priceCalculationContext = priceCalculationContext;
        }

        // Add new constructor if needed to work with another context
    }
}
