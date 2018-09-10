using PriceCalculation.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Data.UnitOfWork
{
    public interface ISearchUoW : IDisposable
    {
        Task Commit();
        IBusinessItemRepository _businessItemRepository { get; }
    }
}
