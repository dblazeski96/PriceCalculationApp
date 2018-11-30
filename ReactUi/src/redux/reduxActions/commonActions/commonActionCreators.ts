import { ActionCreator } from "redux";

import {
  UPDATE_LOGIN_STATUS,
  UPDATE_IS_ON_SEARCH_SCREEN
} from "./commonActionTypes";

import { IUpdateLoginStatus, IUpdateIsOnSearchScreen } from "./commonIActions";

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
