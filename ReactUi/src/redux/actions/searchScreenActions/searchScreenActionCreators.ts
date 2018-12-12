import { ActionCreator } from "redux";

import {
  UPDATE_SELECTED_ITEM,
  UPDATE_SELECTED_SEARCH_PROP,
  UPDATE_SEARCH_TERM
} from "./searchScreenActionTypes";
import {
  IUpdateSelectedItem,
  IUpdateSelectedSearchProp,
  IUpdateSearchTerm
} from "./searchScreenIActions";

import { Item } from "src/models/DataModels/Item";

// Actions
export const updateSelectedItem: ActionCreator<IUpdateSelectedItem> = (
  selectedItem: Item
) => ({
  type: UPDATE_SELECTED_ITEM,
  selectedItem
});

export const updateSelectedSearchProp: ActionCreator<
  IUpdateSelectedSearchProp
> = (selectedSearchProp: string) => ({
  type: UPDATE_SELECTED_SEARCH_PROP,
  selectedSearchProp
});

export const updateSearchTerm: ActionCreator<IUpdateSearchTerm> = (
  searchTerm: string
) => ({
  type: UPDATE_SEARCH_TERM,
  searchTerm
});
