using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Factory
{
    public class PriceCalculationContextFactory : ContextFactory, IPriceCalculationContextFactory
    {
        public override DbContext Create()
        {
            return new PriceCalculationContext();
        }
    }
}
