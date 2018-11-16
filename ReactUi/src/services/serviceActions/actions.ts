import { ActionCreator } from "redux";
import {
  IGetAllServiceAction,
  ISearchServiceAction,
  IChangeMultipleItemsAction,
  IChangeItemAction
} from "./IActions";
import {
  GET_ALL_SERVICE_ACTION,
  SEARCH_SERVICE_ACTION,
  CHANGE_MULTIPLE_ITEMS_ACTION,
  CHANGE_ITEM_ACTION
} from "./actionTypes";

import { IBaseModel } from "../../models/BaseModel/IBaseModel";

export const getAllServiceAction: ActionCreator<
  IGetAllServiceAction
> = (): IGetAllServiceAction => ({
  type: GET_ALL_SERVICE_ACTION
});

export const searchServiceAction: ActionCreator<ISearchServiceAction> = (
  prop: string,
  searchTerm: string
): ISearchServiceAction => ({
  type: SEARCH_SERVICE_ACTION,
  prop,
  searchTerm
});

export const changeMultipleItemsAction: ActionCreator<
  IChangeMultipleItemsAction
> = (
  prop: string,
  value: string,
  items: number[]
): IChangeMultipleItemsAction => ({
  type: CHANGE_MULTIPLE_ITEMS_ACTION,
  prop,
  value,
  items
});

export const changeItemAction: ActionCreator<IChangeItemAction> = (
  item: IBaseModel
): IChangeItemAction => ({
  type: CHANGE_ITEM_ACTION,
  item
});
