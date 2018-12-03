import { Reducer, Action } from "redux";

import { ICommonState } from "../store/IState";
import initialState from "../store/initialState";

import {
  UPDATE_LOGIN_STATUS,
  UPDATE_IS_ON_SEARCH_SCREEN,
  UPDATE_SELECTED_ITEM,
  UPDATE_SEARCH_TERM
} from "../actions/commonActions/commonActionTypes";
import {
  IUpdateLoginStatus,
  IUpdateIsOnSearchScreen,
  IUpdateSelectedItem,
  IUpdateSearchTerm
} from "../actions/commonActions/commonIActions";

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

    case UPDATE_SELECTED_ITEM: {
      const nextState = { ...state };
      nextState.selectedItem = (action as IUpdateSelectedItem).selectedItem;

      return nextState;
    }

    case UPDATE_SEARCH_TERM: {
      const nextState = { ...state };
      nextState.searchTerm = (action as IUpdateSearchTerm).searchTerm;

      return nextState;
    }

    default: {
      return state;
    }
  }
};

export default commonReducer;
