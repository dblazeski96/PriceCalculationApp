using PriceCalculation.Data.Factory;
using PriceCalculation.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.UnitOfWork
{
    public interface ISearchUoW : IUnitOfWork
    {
        IBusinessItemRepository _businessItemRepository { get; }
    }
}
