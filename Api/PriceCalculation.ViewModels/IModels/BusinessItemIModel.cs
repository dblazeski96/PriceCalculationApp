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
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfProduction { get; set; }
        public DateTime DateOfLastSold { get; set; }
        public double PriceCost { get; set; }
    }
}
