using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculation.Mapper;
using System.Collections;
using PriceCalculation.Service;
using System.Reflection;
using PriceCalculation.Data.Repository;
using PriceCalculation.Models.Base;
using PriceCalculation.Data.UnitOfWork;
using PriceCalculation.Models.View;
using PriceCalculation.Models.Data;

namespace PriceCalculation.Service
{
    public class SearchService : BaseService, ISearchService
    {
        private IPriceCalculationUoW _priceCalculationUoW;

        public SearchService(IPriceCalculationUoW priceCalculationUoW)
        {
            _priceCalculationUoW = priceCalculationUoW;
        }

        //
        // Business Item
        //
        public ServiceResult<BusinessItemOModel> CreateBusinessItem(BusinessItemIModel businessItem)
        {
            try
            {
                var serviceResult = Create<BusinessItem, BusinessItemOModel>(
                    _priceCalculationUoW._businessItemRepository,
                    businessItem.MapToDataModel<BusinessItem>());

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
        public ServiceResult<BusinessItemOModel> ChangeBusinessItem(BusinessItemIModel businessItem)
        {
            try
            {
                var serviceResult = Change<BusinessItem, BusinessItemOModel>(
                    _priceCalculationUoW._businessItemRepository,
                    businessItem.MapToDataModel<BusinessItem>());

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
        public ServiceResult<BusinessItemOModel> RemoveBusinessItem(int id)
        {
            try
            {
                var serviceResult = Remove<BusinessItem, BusinessItemOModel>(
                    _priceCalculationUoW._businessItemRepository,
                    id);

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }
        public ServiceResult<BusinessItemOModel> GetBusinessItem(int id)
        {
            var serviceResult = Get<BusinessItem, BusinessItemOModel>(
                _priceCalculationUoW._businessItemRepository,
                id);

            return serviceResult;
        }
        public ServiceResult<BusinessItemOModel> GetAllBusinessItems(string property, string searchCriteria)
        {
            var serviceResult = GetAll<BusinessItem, BusinessItemOModel>(
                _priceCalculationUoW._businessItemRepository,
                property,
                searchCriteria);

            return serviceResult;
        }
        public ServiceResult<BusinessItemOModel> ChangePropertyOfMultipleBusinessItems(string property, string value, IEnumerable<int> items)
        {
            try
            {
                var serviceResult = ChangePropertyOfMultipleItems<BusinessItem, BusinessItemOModel>(
                    _priceCalculationUoW._businessItemRepository,
                    property,
                    value,
                    items);

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessItemOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }

        //
        // Business Entity
        //
        public ServiceResult<BusinessEntityOModel> CreateBusinessEntity(BusinessEntityIModel businessEntity)
        {
            try
            {
                var serviceResult = Create<BusinessEntity, BusinessEntityOModel>(
                    _priceCalculationUoW._businessEntityRepository,
                    businessEntity.MapToDataModel<BusinessEntity>());

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessEntityOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
            
        }
        public ServiceResult<BusinessEntityOModel> ChangeBusinessEntity(BusinessEntityIModel businessEntity)
        {
            try
            {
                var serviceResult = Change<BusinessEntity, BusinessEntityOModel>(
                    _priceCalculationUoW._businessEntityRepository,
                    businessEntity.MapToDataModel<BusinessEntity>());

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessEntityOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
            
        }
        public ServiceResult<BusinessEntityOModel> RemoveBusinessEntity(int id)
        {
            try
            {
                var serviceResult = Remove<BusinessEntity, BusinessEntityOModel>(
                    _priceCalculationUoW._businessEntityRepository,
                    id);

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessEntityOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
            
        }
        public ServiceResult<BusinessEntityOModel> GetBusinessEntity(int id)
        {
            var serviceResult = Get<BusinessEntity, BusinessEntityOModel>(
                _priceCalculationUoW._businessEntityRepository,
                id);

            return serviceResult;
        }
        public ServiceResult<BusinessEntityOModel> GetAllBusinessEntities(string property, string searchCriteria)
        {
            var serviceResult = GetAll<BusinessEntity, BusinessEntityOModel>(
                _priceCalculationUoW._businessEntityRepository,
                property,
                searchCriteria);

            return serviceResult;
        }

        public ServiceResult<BusinessEntityOModel> ChangePropertyOfMultipleBusinessEntities(string property, string value, IEnumerable<int> items)
        {
            try
            {
                var serviceResult = ChangePropertyOfMultipleItems<BusinessEntity, BusinessEntityOModel>(
                    _priceCalculationUoW._businessEntityRepository,
                    property,
                    value,
                    items);

                _priceCalculationUoW.Commit();

                return serviceResult;
            }
            catch (Exception ex)
            {
                return new ServiceResult<BusinessEntityOModel>
                {
                    Success = false,
                    ex = ex
                };
            }
        }



        public void Dispose()
        {
            _priceCalculationUoW.Dispose();
        }
    }
}
