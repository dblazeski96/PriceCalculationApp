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
    public class Catalogue : BaseDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int BusinessEntityId { get; set; }
        public BusinessEntity BusinessEntity { get; set; }

        public virtual ICollection<CatalogueItem> CatalogueItems { get; set; }
    }
}
