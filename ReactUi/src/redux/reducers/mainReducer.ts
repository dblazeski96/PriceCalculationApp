import { Reducer, Action } from "redux";

import { IMainState } from "../store/IReduxState";
import initialReduxState from "../store/initialReduxState";

import {
  UPDATE_LOGIN_STATUS,
  UPDATE_IS_ON_SEARCH_SCREEN
} from "../actions/mainActions/mainActionTypes";

import {
  IUpdateLoginStatus,
  IUpdateIsOnSearchScreen
} from "../actions/mainActions/mainIActions";

// Reducer
const mainReducer: Reducer<IMainState, Action<string>> = (
  state = initialReduxState.mainState,
  action
) => {
  switch (action.type) {
    case UPDATE_LOGIN_STATUS: {
      const nextState = { ...state };
      const nextAction = action as IUpdateLoginStatus;

      nextState.loggedIn = nextAction.loggedIn;

      return nextState;
    }

    case UPDATE_IS_ON_SEARCH_SCREEN: {
      const nextState = { ...state };
      const nextAction = action as IUpdateIsOnSearchScreen;

      nextState.isOnSearchScreen = nextAction.isOnSearchScreen;

      return nextState;
    }

    default: {
      return state;
    }
  }
};

export default mainReducer;
