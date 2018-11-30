import { Action, Reducer } from "redux";

import { ISearchScreenState } from "../reduxStore/IState";
import initialState from "../reduxStore/initialState";

import {
  UPDATE_SELECTED_ITEM,
  UPDATE_SELECTED_SEARCH_PROP,
  UPDATE_SEARCH_TERM,
  SELECT_DESELECT_DATA_ITEM,
  UPDATE_SELECTED_CHANGE_PROP,
  UPDATE_CHANGE_PROP_VALUE
} from "../reduxActions/searchScreenActions/searchScreenActionTypes";

import {
  IUpdateSelectedItem,
  IUpdateSelectedSearchProp,
  IUpdateSearchTerm,
  ISelectDeselectDataItem,
  IUpdateSelectedChangeProp,
  IUpdateChangePropValue
} from "../reduxActions/searchScreenActions/searchScreenIActions";

const searchScreenReducer: Reducer<ISearchScreenState> = (
  state: ISearchScreenState = initialState.searchScreenState,
  action: Action<string>
): ISearchScreenState => {
  switch (action.type) {
    case UPDATE_SELECTED_ITEM: {
      const nextState = { ...state };
      nextState.selectedItem = (action as IUpdateSelectedItem).selectedItem;
      nextState.itemData = (action as IUpdateSelectedItem).data;
      nextState.itemProps = Object.keys(nextState.itemData[0]);

      nextState.searchProps = Object.keys(nextState.itemData[0]);
      nextState.defaultSelectedSearchProp = nextState.searchProps[0];
      nextState.selectedSearchProp = nextState.searchProps[0];
      nextState.searchTerm = "";

      nextState.changeProps = Object.keys(nextState.itemData[0]).filter(
        p => p.toLowerCase() !== "id"
      );
      nextState.defaultSelectedChangeProp = nextState.changeProps[0];
      nextState.selectedChangeProp = nextState.changeProps[0];
      nextState.changePropValue = "";
      nextState.selectedDataItems = [];

      return nextState;
    }

    case UPDATE_SELECTED_SEARCH_PROP: {
      const nextState = { ...state };
      nextState.selectedSearchProp = (action as IUpdateSelectedSearchProp).prop;

      return nextState;
    }

    case UPDATE_SEARCH_TERM: {
      const nextState = { ...state };
      nextState.searchTerm = (action as IUpdateSearchTerm).searchTerm;

      return nextState;
    }

    case UPDATE_SELECTED_CHANGE_PROP: {
      const nextState = { ...state };
      nextState.selectedChangeProp = (action as IUpdateSelectedChangeProp).prop;

      return nextState;
    }

    case UPDATE_CHANGE_PROP_VALUE: {
      const nextState = { ...state };
      nextState.changePropValue = (action as IUpdateChangePropValue).propValue;

      return nextState;
    }

    case SELECT_DESELECT_DATA_ITEM: {
      const nextState = { ...state };
      const actionId = (action as ISelectDeselectDataItem).id;
      const selectedItems = nextState.selectedDataItems;

      nextState.selectedDataItems =
        selectedItems.indexOf(actionId) === -1
          ? [...selectedItems, actionId]
          : [...selectedItems.filter(i => i !== actionId)];

      return nextState;
    }

    default: {
      return state;
    }
  }
};

export default searchScreenReducer;
