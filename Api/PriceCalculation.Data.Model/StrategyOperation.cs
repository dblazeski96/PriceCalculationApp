using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.Models
{
    public class StrategyOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StrategyId { get; set; }
        public Strategy Strategy { get; set; }

        [Required]
        public int EquationOperationId { get; set; }
        public EquationOperation EquationOperation { get; set; }
    }
}
