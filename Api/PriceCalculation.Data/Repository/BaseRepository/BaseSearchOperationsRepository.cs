using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Mapper;
using PriceCalculation.Models.Base;

namespace PriceCalculation.Data.Repository
{
    public abstract partial class BaseRepository<T>
    {
        // Search Operation: Change Proerty Of Multiple Items
        public virtual RepositoryResult<T> ChangePropertyOfMultipleItems(string property, string value, IEnumerable<int> items)
        {
            try
            {
                var dbSet = _dbContext.Set<T>();
                var dbSetIncluded = dbSet.IncludePropsToDbSet();

                var itemsToChange = dbSetIncluded.ToList().Where(i => items.Contains((int)i.GetType().GetProperty("Id").GetValue(i)));

                foreach (var item in itemsToChange)
                {
                    var itemProperty = item.GetType().GetProperty(property);
                    itemProperty.SetValue(item, Convert.ChangeType(value, itemProperty.PropertyType));
                }

                return new RepositoryResult<T>
                {
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<T>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
    }
}
