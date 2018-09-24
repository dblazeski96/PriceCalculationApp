﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Models;
using System.Data.Entity;

namespace PriceCalculation.Data.Repository
{
    public class RuleRepository : BaseRepository<Rule>, IRuleRepository
    {
        public RuleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}