using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Models
{
    public class StrategyRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StrategyId { get; set; }
        public Strategy Strategy { get; set; }

        public int RuleId { get; set; }
        public Rule Rule { get; set; }
    }
}
