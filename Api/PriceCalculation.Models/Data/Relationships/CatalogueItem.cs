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
    public class CatalogueItem : BaseDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int BusinessItemId { get; set; }
        public BusinessItem BusinessItem { get; set; }

        [Required]
        public int CatalogueId { get; set; }
        public Catalogue Catalogue { get; set; }
    }
}
