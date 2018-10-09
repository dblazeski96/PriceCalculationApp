using PriceCalculation.Data.Repository;
using PriceCalculation.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculation.Service
{
    public abstract partial class BaseService
    {
        protected ServiceResult<TOutput> ChangePropertyOfMultipleItems<TInput, TOutput>(IRepository<TInput> repository, string property, string value, IEnumerable<int> items)
            where TInput : class, BaseDataModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repositoryResult = repository.ChangePropertyOfMultipleItems(property, value, items);
                if (!repositoryResult.Success)
                {
                    return new ServiceResult<TOutput>
                    {
                        Success = false,
                        ex = repositoryResult.ex
                    };
                }

                return new ServiceResult<TOutput>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TOutput>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
    }
}
