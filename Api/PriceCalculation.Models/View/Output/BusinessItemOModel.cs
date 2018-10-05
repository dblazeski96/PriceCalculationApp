using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Models.View
{
    public class BusinessItemOModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public int Quantity { get; set; }
        public double PriceCost { get; set; }
        public double PriceTarget { get; set; }
        public double PricePremium { get; set; }
        public string DateOfProduction { get; set; }
        public string DateOfLastSoldItem { get; set; }
    }
}
