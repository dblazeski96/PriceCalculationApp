using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Models.View
{
    public class BusinessItemIModel : BaseViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public int Quantity { get; set; }
        public string DateOfProduction { get; set; }
        public string DateOfLastSold { get; set; }
        public double PriceCost { get; set; }
    }
}
