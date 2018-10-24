import { Action, Reducer } from "redux";

import { ISearchScreenState } from "../store/IState";
import { initialState } from "../store/initialState";

import {
  UPDATE_SELECTED_ITEM,
  UPDATE_SELECTED_SEARCH_PROP,
  UPDATE_SEARCH_TERM,
  UPDATE_SELECTED_CHANGE_PROP,
  UPDATE_CHANGE_PROP_VALUE,
  SELECT_DESELECT_DATA_ITEM
} from "../actions/actionTypes";

import {
  IUpdateSelectedItem,
  IUpdateSelectedSearchProp,
  IUpdateSearchTerm,
  IUpdateSelectedChangeProp,
  IUpdateChangePropValue,
  ISelectDeselectDataItem
} from "../actions/IActions";

export const searchScreenReducer: Reducer<ISearchScreenState> = (
  state: ISearchScreenState = initialState.searchScreenReducer,
  action: Action<string>
): ISearchScreenState => {
  switch (action.type) {
    // Need to finish update selected item to convert fetched data to IBASEMODEL(IBusinessItem?, IBusinessEntity?)
    case UPDATE_SELECTED_ITEM: {
      const nextState = { ...state };
      nextState.selectedItem = (action as IUpdateSelectedItem).selectedItem;
      nextState.itemData = (action as IUpdateSelectedItem).data;
      nextState.searchProps = Object.keys(nextState.itemData[0]);
      nextState.changeProps = Object.keys(nextState.itemData[0]);

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
