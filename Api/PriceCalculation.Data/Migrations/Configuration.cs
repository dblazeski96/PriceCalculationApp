namespace PriceCalculation.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PriceCalculation.Data.PriceCalculationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PriceCalculation.Data.PriceCalculationContext";
        }

        protected override void Seed(PriceCalculation.Data.PriceCalculationContext context)
        {
            context.EquationOperations.AddOrUpdate(
                new EquationOperation
                {
                    Operation = Operation.Add
                },
                new EquationOperation
                {
                    Operation = Operation.Subtract
                },
                new EquationOperation
                {
                    Operation = Operation.Multiply
                },
                new EquationOperation
                {
                    Operation = Operation.Subtract
                }
            );
            context.SaveChanges();

            context.Rules.AddOrUpdate(
                new Rule
                {
                    Name = "Rule 1",
                    Equation1 = "eq1",
                    Equation2 = "eq2",
                    Operation = context.EquationOperations.Find(1)
                },
                new Rule
                {
                    Name = "Rule 2",
                    Equation1 = "eq1",
                    Equation2 = "eq2",
                    Operation = context.EquationOperations.Find(2)
                }
            );
            context.SaveChanges();

            context.Strategies.AddOrUpdate(
                new Strategy
                {
                    Name = "Simple strategy 1"
                },
                new Strategy
                {
                    Name = "Simple strategy 2"
                }
            );
            context.SaveChanges();

            context.StrategyRules.AddOrUpdate(
                new StrategyRule
                {
                    RuleId = 1,
                    StrategyId = 1
                },
                new StrategyRule
                {
                    RuleId = 2,
                    StrategyId = 1
                },
                new StrategyRule
                {
                    RuleId = 1,
                    StrategyId = 2
                },
                new StrategyRule
                {
                    RuleId = 2,
                    StrategyId = 2
                }
            );
            context.SaveChanges();

            context.StrategyOperations.AddOrUpdate(
                new StrategyOperation
                {
                    EquationOperationId = 1,
                    StrategyId = 1
                },
                new StrategyOperation
                {
                    EquationOperationId = 2,
                    StrategyId = 2
                }
            );
            context.SaveChanges();

            context.Groups.AddOrUpdate(
                new Group
                {
                    Name = "Cheap items",
                    StrategyId = 1
                },
                new Group
                {
                    Name = "Expensive items",
                    StrategyId = 2
                }
            );
            context.SaveChanges();

            context.Items.AddOrUpdate(
                new Item
                {
                    Name = "Dejan Item 1",
                    Description = "simple test item",
                    GroupId = 1
                },
                new Item
                {
                    Name = "Marko Item 1",
                    Description = "simple test item",
                    GroupId = 2
                }
            );
            context.SaveChanges();

            context.BusinessEntities.AddOrUpdate(
                new BusinessEntity
                {
                    Name = "Fist fight business",
                    Type = BusinessType.SalesCompany,
                    Currency = Currency.Dollar
                },
                new BusinessEntity
                {
                    Name = "Guns fight business",
                    Type = BusinessType.ProductCompany,
                    Currency = Currency.Denar
                }
            );
            context.SaveChanges();

            context.BusinessItems.AddOrUpdate(
                new BusinessItem
                {
                    ItemId = 1,
                    //BusinessEntityId = 1,
                    Quantity = 12,
                    DateOfProduction = new DateTime(2017, 2, 17),
                    DateOfLastSold = new DateTime(2018, 8, 12)
                },
                new BusinessItem
                {
                    ItemId = 2,
                    //BusinessEntityId = 1,
                    Quantity = 51,
                    DateOfProduction = new DateTime(2017, 5, 14),
                    DateOfLastSold = new DateTime(2018, 7, 1)
                },
                new BusinessItem
                {
                    ItemId = 2,
                    //BusinessEntityId = 2,
                    Quantity = 32,
                    DateOfProduction = new DateTime(2017, 9, 2),
                    DateOfLastSold = new DateTime(2018, 9, 23)
                }
            );
            context.SaveChanges();

            context.Prices.AddOrUpdate(
                new Price
                {
                    BusinessItemId = 1,
                    Type = PriceType.Cost,
                    Amount = 200
                },
                new Price
                {
                    BusinessItemId = 1,
                    Type = PriceType.Target,
                    Amount = 300
                },
                new Price
                {
                    BusinessItemId = 1,
                    Type = PriceType.Premium,
                    Amount = 450
                },
                new Price
                {
                    BusinessItemId = 2,
                    Type = PriceType.Cost,
                    Amount = 140
                },
                new Price
                {
                    BusinessItemId = 2,
                    Type = PriceType.Target,
                    Amount = 180
                },
                new Price
                {
                    BusinessItemId = 2,
                    Type = PriceType.Premium,
                    Amount = 250
                },
                new Price
                {
                    BusinessItemId = 3,
                    Type = PriceType.Cost,
                    Amount = 100
                },
                new Price
                {
                    BusinessItemId = 3,
                    Type = PriceType.Target,
                    Amount = 180
                },
                new Price
                {
                    BusinessItemId = 3,
                    Type = PriceType.Premium,
                    Amount = 300
                }
            );
            context.SaveChanges();

            context.Catalogues.AddOrUpdate(
                new Catalogue
                {
                    Name = "Fist fight catalogue",
                    BusinessEntityId = 1
                },
                new Catalogue
                {
                    Name = "Guns fiht catalogue",
                    BusinessEntityId = 2
                }
            );
            context.SaveChanges();

            context.CatalogueItems.AddOrUpdate(
                new CatalogueItem
                {
                    BusinessItemId = 1,
                    CatalogueId = 1,
                },
                new CatalogueItem
                {
                    BusinessItemId = 2,
                    CatalogueId = 1
                },
                new CatalogueItem
                {
                    BusinessItemId = 3,
                    CatalogueId = 2
                }
            );
            context.SaveChanges();
        }
    }
}
