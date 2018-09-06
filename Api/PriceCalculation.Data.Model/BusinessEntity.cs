using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Models
{
    public class BusinessEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public BusinessType Type { get; set; }

        public Currency Currency { get; set; }

        public List<Catalogue> Catalogues { get; set; }
    }
}
