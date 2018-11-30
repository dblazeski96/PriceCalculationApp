import { Reducer, Action } from "redux";

import { ICommonState } from "../reduxStore/IState";
import initialState from "../reduxStore/initialState";

import {
  UPDATE_LOGIN_STATUS,
  UPDATE_IS_ON_SEARCH_SCREEN
} from "../reduxActions/commonActions/commonActionTypes";
import {
  IUpdateLoginStatus,
  IUpdateIsOnSearchScreen
} from "../reduxActions/commonActions/commonIActions";

// Reducer
const commonReducer: Reducer<ICommonState> = (
  state: ICommonState = initialState.commonState,
  action: Action<string>
) => {
  switch (action.type) {
    case UPDATE_LOGIN_STATUS: {
      const nextState = { ...state };
      nextState.loggedIn = (action as IUpdateLoginStatus).loggedIn;

      return nextState;
    }

    case UPDATE_IS_ON_SEARCH_SCREEN: {
      const nextState = { ...state };
      nextState.isOnSearchScreen = (action as IUpdateIsOnSearchScreen).isOnSearchScreen;

      return nextState;
    }

    default: {
      return state;
    }
  }
};

export default commonReducer;
