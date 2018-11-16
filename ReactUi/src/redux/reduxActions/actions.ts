import { ActionCreator } from "redux";

import {
  IUpdateSelectedItem,
  IUpdateSelectedSearchProp,
  IUpdateSearchTerm,
  IUpdateSelectedChangeProp,
  IUpdateChangePropValue,
  ISelectDeselectDataItem,
  IUpdateLoginStatus
} from "./IActions";

import {
  UPDATE_SELECTED_ITEM,
  UPDATE_SELECTED_SEARCH_PROP,
  UPDATE_SEARCH_TERM,
  UPDATE_SELECTED_CHANGE_PROP,
  UPDATE_CHANGE_PROP_VALUE,
  SELECT_DESELECT_DATA_ITEM,
  UPDATE_LOGIN_STATUS
} from "./actionTypes";
import { IBaseModel } from "src/models/BaseModel/IBaseModel";

export const updateSelectedItem: ActionCreator<IUpdateSelectedItem> = (
  selectedItem: string,
  data: IBaseModel[]
): IUpdateSelectedItem => ({
  type: UPDATE_SELECTED_ITEM,
  selectedItem,
  data
});

export const updateSelectedSearchProp: ActionCreator<
  IUpdateSelectedSearchProp
> = (prop: string): IUpdateSelectedSearchProp => ({
  type: UPDATE_SELECTED_SEARCH_PROP,
  prop
});

export const updateSearchTerm: ActionCreator<IUpdateSearchTerm> = (
  searchTerm: string
): IUpdateSearchTerm => ({
  type: UPDATE_SEARCH_TERM,
  searchTerm
});

export const updateSelectedChangeProp: ActionCreator<
  IUpdateSelectedChangeProp
> = (prop: string): IUpdateSelectedChangeProp => ({
  type: UPDATE_SELECTED_CHANGE_PROP,
  prop
});

export const updateChangePropValue: ActionCreator<IUpdateChangePropValue> = (
  propValue: string
): IUpdateChangePropValue => ({
  type: UPDATE_CHANGE_PROP_VALUE,
  propValue
});

export const selectDeselectDataItem: ActionCreator<ISelectDeselectDataItem> = (
  id: number
): ISelectDeselectDataItem => ({
  type: SELECT_DESELECT_DATA_ITEM,
  id
});

export const updateLoginStatus: ActionCreator<IUpdateLoginStatus> = (
  loggedIn: boolean
): IUpdateLoginStatus => ({
  type: UPDATE_LOGIN_STATUS,
  loggedIn
});
