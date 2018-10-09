using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using PriceCalculation.Mapper;
using PriceCalculation.Models.Base;
using PriceCalculation.Data.Repository;
using PriceCalculation.Data.UnitOfWork;

namespace PriceCalculation.Service
{
    public abstract partial class BaseService
    {
        // Service CRUD: Create
        protected ServiceResult<TOutput> Create<TInput, TOutput>(IRepository<TInput> repository, TInput item)
            where TInput : class, BaseDataModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repositoryResult = repository.Create(item);
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

        // Service CRUD: Change
        protected ServiceResult<TOutput> Change<TInput, TOutput>(IRepository<TInput> repository, TInput item)
            where TInput : class, BaseDataModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repositoryResult = repository.Change(item);
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

        // Service CRUD: Remove
        protected ServiceResult<TOutput> Remove<TInput, TOutput>(IRepository<TInput> repository, int id)
            where TInput : class, BaseDataModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repositoryResult = repository.Remove(id);
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

        // Service CRUD: Get
        protected ServiceResult<TOutput> Get<TInput, TOutput>(IRepository<TInput> repository, int id)
            where TInput : class, BaseDataModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repositoryResult = repository.Get(id);
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
                    Success = true,
                    Item = repositoryResult.item.MapToViewModel<TOutput>()
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

        // Service CRUD: GetAll
        protected ServiceResult<TOutput> GetAll<TInput, TOutput>(IRepository<TInput> repository, string property, string searchCriteria)
            where TInput : class, BaseDataModel
            where TOutput : class, BaseViewModel
        {
            try
            {
                var repositoryResult = repository.GetAll(property, searchCriteria);
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
                    Success = true,
                    Items = repositoryResult.items.Select(i => i.MapToViewModel<TOutput>()).ToList()
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
