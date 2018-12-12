import { Reducer, Action } from "redux";

import { ISearchScreenState } from "../store/IReduxState";
import initialReduxState from "../store/initialReduxState";

import {
  UPDATE_SELECTED_ITEM,
  UPDATE_SELECTED_SEARCH_PROP,
  UPDATE_SEARCH_TERM
} from "../actions/searchScreenActions/searchScreenActionTypes";
import {
  IUpdateSelectedItem,
  IUpdateSelectedSearchProp,
  IUpdateSearchTerm
} from "../actions/searchScreenActions/searchScreenIActions";

// Reducer
const searchScreenReducer: Reducer<ISearchScreenState, Action<string>> = (
  state = initialReduxState.searchScreenState,
  action
) => {
  switch (action.type) {
    case UPDATE_SELECTED_ITEM: {
      const nextState = { ...state };
      const nextAction = action as IUpdateSelectedItem;

      nextState.selectedItem = nextAction.selectedItem;

      return nextState;
    }

    case UPDATE_SELECTED_SEARCH_PROP: {
      const nextState = { ...state };
      const nextAction = action as IUpdateSelectedSearchProp;

      nextState.selectedSearchProp = nextAction.selectedSearchProp;

      return nextState;
    }

    case UPDATE_SEARCH_TERM: {
      const nextState = { ...state };
      const nextAction = action as IUpdateSearchTerm;

      nextState.searchTerm = nextAction.searchTerm;

      return nextState;
    }

    default: {
      return state;
    }
  }
};

export default searchScreenReducer;
