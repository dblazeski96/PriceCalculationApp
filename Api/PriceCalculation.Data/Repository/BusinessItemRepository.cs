using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PriceCalculation.Models.Data;
using PriceCalculation.Mapper;
using System.Reflection;

namespace PriceCalculation.Data.Repository
{
    public class BusinessItemRepository : BaseRepository<BusinessItem>, IBusinessItemRepository
    {
        public BusinessItemRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override RepositoryResult<BusinessItem> ChangePropertyOfMultipleItems(string property, string value, IEnumerable<int> items)
        {
            try
            {
                var dbSet = _dbContext.Set<BusinessItem>();
                var dbSetIncluded = dbSet.IncludePropsToDbSet();

                var businessItems = dbSetIncluded.ToList().Where(i => items.Contains(i.Id));
                PropertyInfo itemProperty = null;
                bool isPropertyInMainObject = true;

                foreach (var businessItem in businessItems)
                {
                    if (itemProperty == null)
                    {
                        itemProperty = businessItem.GetType().GetProperty(property);
                        if (itemProperty == null)
                        {
                            itemProperty = businessItem.Item.GetType().GetProperty(property);
                            isPropertyInMainObject = false;
                        }
                    }

                    if (isPropertyInMainObject)
                    {
                        itemProperty.SetValue(businessItem, Convert.ChangeType(value, itemProperty.PropertyType));
                    }
                    else
                    {
                        itemProperty.SetValue(businessItem.Item, Convert.ChangeType(value, itemProperty.PropertyType));
                    }
                }

                return new RepositoryResult<BusinessItem>
                {
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResult<BusinessItem>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
    }
}
