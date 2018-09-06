using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;

namespace PriceCalculation.Data
{
    public class PriceCalculationContext : DbContext
    {
        public PriceCalculationContext() : base("name=PriceCalculationConnection")
        {
        }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Strategy> Strategies { get; set; }
        public virtual DbSet<StrategyRule> StrategyRules { get; set; }
        public virtual DbSet<StrategyOperation> StrategyOperations { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<EquationOperation> EquationOperations { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<BusinessItem> BusinessItems { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Catalogue> Catalogues { get; set; }
        public virtual DbSet<CatalogueItem> CatalogueItems { get; set; }
    }
}
