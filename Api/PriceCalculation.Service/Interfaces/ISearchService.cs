using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;
using PriceCalculation.Models.View;

namespace PriceCalculation.Service
{
    public interface ISearchService : IDisposable
    {
        ServiceResult<BusinessItemOModel> CreateBusinessItem(BusinessItemIModel businessItem);
        ServiceResult<BusinessItemOModel> ChangeBusinessItem(BusinessItemIModel businessItem);
        ServiceResult<BusinessItemOModel> RemoveBusinessItem(int id);
        ServiceResult<BusinessItemOModel> GetBusinessItem(int id);
        ServiceResult<BusinessItemOModel> GetAllBusinessItems(string property, string searchCriteria);
        ServiceResult<BusinessItemOModel> ChangePropertyOfMultipleBusinessItems(string property, string value, IEnumerable<int> items);

        ServiceResult<BusinessEntityOModel> CreateBusinessEntity(BusinessEntityIModel businessItem);
        ServiceResult<BusinessEntityOModel> ChangeBusinessEntity(BusinessEntityIModel businessItem);
        ServiceResult<BusinessEntityOModel> RemoveBusinessEntity(int id);
        ServiceResult<BusinessEntityOModel> GetBusinessEntity(int id);
        ServiceResult<BusinessEntityOModel> GetAllBusinessEntities(string property, string searchCriteria);
        ServiceResult<BusinessEntityOModel> ChangePropertyOfMultipleBusinessEntities(string property, string value, IEnumerable<int> items);
    }
}
