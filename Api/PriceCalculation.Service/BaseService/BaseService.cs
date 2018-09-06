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
        protected BusinessItemRepository BusinessItemRepository;
        public BaseService()
        {
            BusinessItemRepository = new BusinessItemRepository();
        }
        
        public void Dispose()
        {
            BusinessItemRepository.Dispose();
        }
    }
}
