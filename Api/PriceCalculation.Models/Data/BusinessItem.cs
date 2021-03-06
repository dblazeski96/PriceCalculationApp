﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Models.Data
{
    public class BusinessItem : BaseDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime DateOfProduction { get; set; }
        public DateTime DateOfLastSold { get; set; }

        public virtual ICollection<Price> Prices { get; set; }

        public virtual ICollection<CatalogueItem> Catalogues { get; set; }
    }
}
