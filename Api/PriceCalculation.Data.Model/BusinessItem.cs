using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Models
{
    public class BusinessItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public DateTime DateOfProduction { get; set; }
        public DateTime DateOfLastSold { get; set; }

        public List<Price> Prices { get; set; }

        public List<CatalogueItem> Catalogues { get; set; }
    }
}
