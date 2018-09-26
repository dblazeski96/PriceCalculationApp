using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.ViewModels
{
    public class BusinessItemIModel
    {
        public int Id { get; set; }
        public ItemIModel Item { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfProduction { get; set; }
        public DateTime DateOfLastSold { get; set; }
        public double PriceCost { get; set; }
    }
}
