import { ActionCreator } from "redux";

import {
  UPDATE_LOGIN_STATUS,
  UPDATE_IS_ON_SEARCH_SCREEN
} from "./mainActionTypes";

import { IUpdateLoginStatus, IUpdateIsOnSearchScreen } from "./mainIActions";

// Actions
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
