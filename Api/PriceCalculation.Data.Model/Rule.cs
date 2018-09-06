using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Models
{
    public class Rule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Equation1 { get; set; }

        [MaxLength(10)]
        public string Equation2 { get; set; }

        public EquationOperation Operation { get; set; }

        public List<StrategyRule> Strategies { get; set; }
    }
}
