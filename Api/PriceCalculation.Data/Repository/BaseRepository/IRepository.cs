using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Data.Repository
{
    public interface IRepository<T>
        where T : class, BaseDataModel
    {
        // CRUD Operations
        RepositoryResult<T> Create(T item);

        RepositoryResult<T> Change(T item);

        RepositoryResult<T> Remove(int id);

        RepositoryResult<T> Get(int id);

        RepositoryResult<T> GetAll(string property, string searchCriteria);

        // Search Operations
        RepositoryResult<T> ChangePropertyOfMultipleItems(string property, string value, IEnumerable<int> items);
    }
}
