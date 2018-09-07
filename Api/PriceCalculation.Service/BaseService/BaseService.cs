using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Data.Repository;

namespace PriceCalculation.Service
{
    public class BaseService : IDisposable
    {
        protected readonly IBusinessItemRepository _businessItemRepository;
        public BaseService(IBusinessItemRepository businessItemRepository)
        {
            _businessItemRepository = businessItemRepository;
        }
        
        public void Dispose()
        {
            _businessItemRepository.Dispose();
        }
    }
}
