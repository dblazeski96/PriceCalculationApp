import {
  getAllBusinessItems,
  searchBusinessItems,
  changeMultipleBusinessItems
} from "./BusinessItemService";
import {
  getAllBusinessEntities,
  searchBusinessEntities,
  changeMultipleBusinessEntities
} from "./BusinessEntityService";
import { AxiosPromise } from "axios";
import { IBaseModel } from "src/models/BaseModel/IBaseModel";
import {
  GET_ALL_SERVICE_ACTION,
  SEARCH_SERVICE_ACTION,
  CHANGE_MULTIPLE_ITEMS_ACTION
} from "./serviceActions/actionTypes";
import { AnyAction } from "redux";
import {
  ISearchServiceAction,
  IChangeMultipleItemsAction
} from "./serviceActions/IActions";

export const determineDataItemPromise = (
  selectedItem: string,
  action: AnyAction
): AxiosPromise<IBaseModel[]> => {
  switch (action.type) {
    case GET_ALL_SERVICE_ACTION: {
      switch (selectedItem) {
        case "businessItem": {
          return getAllBusinessItems();
        }
        case "businessEntity": {
          return getAllBusinessEntities();
        }
        default: {
          return getAllBusinessItems();
        }
      }
    }

    case SEARCH_SERVICE_ACTION: {
      switch (selectedItem) {
        case "businessItem": {
          const actionDetermined = action as ISearchServiceAction;

          return searchBusinessItems(
            actionDetermined.prop,
            actionDetermined.searchTerm
          );
        }
        case "businessEntity": {
          const actionDetermined = action as ISearchServiceAction;

          return searchBusinessEntities(
            actionDetermined.prop,
            actionDetermined.searchTerm
          );
        }
        default: {
          const actionDetermined = action as ISearchServiceAction;

          return searchBusinessItems(
            actionDetermined.prop,
            actionDetermined.searchTerm
          );
        }
      }
    }

    case CHANGE_MULTIPLE_ITEMS_ACTION: {
      switch (selectedItem) {
        case "businessItem": {
          const actionDetermined = action as IChangeMultipleItemsAction;

          return changeMultipleBusinessItems(
            actionDetermined.prop,
            actionDetermined.value,
            actionDetermined.items
          );
        }
        case "businessEntity": {
          const actionDetermined = action as IChangeMultipleItemsAction;

          return changeMultipleBusinessEntities(
            actionDetermined.prop,
            actionDetermined.value,
            actionDetermined.items
          );
        }
        default: {
          const actionDetermined = action as IChangeMultipleItemsAction;

          return changeMultipleBusinessItems(
            actionDetermined.prop,
            actionDetermined.value,
            actionDetermined.items
          );
        }
      }
    }

    default:
      switch (selectedItem) {
        case "businessItem": {
          return getAllBusinessItems();
        }
        case "businessEntity": {
          return getAllBusinessEntities();
        }
        default: {
          return getAllBusinessItems();
        }
      }
  }
};
