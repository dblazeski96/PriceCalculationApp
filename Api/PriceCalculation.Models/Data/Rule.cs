using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Models.Data
{
    public class Rule : BaseDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Equation1 { get; set; }

        [Required]
        [MaxLength(10)]
        public string Equation2 { get; set; }

        [Required]
        public EquationOperation Operation { get; set; }

        public virtual ICollection<StrategyRule> Strategies { get; set; }
    }
}
