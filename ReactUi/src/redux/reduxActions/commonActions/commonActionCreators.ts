import { ActionCreator } from "redux";

import {
  UPDATE_LOGIN_STATUS,
  UPDATE_IS_ON_SEARCH_SCREEN,
  UPDATE_SELECTED_ITEM,
  UPDATE_SEARCH_TERM
} from "./commonActionTypes";

import {
  IUpdateLoginStatus,
  IUpdateIsOnSearchScreen,
  IUpdateSelectedItem,
  IUpdateSearchTerm
} from "./commonIActions";

export const updateLoginStatus: ActionCreator<IUpdateLoginStatus> = (
  loggedIn: boolean
) => ({
  type: UPDATE_LOGIN_STATUS,
  loggedIn
});

export const updateIsOnSearchScreen: ActionCreator<IUpdateIsOnSearchScreen> = (
  isOnSearchScreen: boolean
) => ({
  type: UPDATE_IS_ON_SEARCH_SCREEN,
  isOnSearchScreen
});

export const updateSelectedItem: ActionCreator<IUpdateSelectedItem> = (
  selectedItem: string
) => ({
  type: UPDATE_SELECTED_ITEM,
  selectedItem
});

export const updateSearchTerm: ActionCreator<IUpdateSearchTerm> = (
  searchTerm: string
) => ({
  type: UPDATE_SEARCH_TERM,
  searchTerm
});
