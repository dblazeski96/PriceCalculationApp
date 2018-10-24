import { IState } from "./IState";

export const initialState: IState = {
  searchScreenReducer: {
    defaultSelectedItem: "businessItem",
    selectedItem: "businessItem",
    itemData: [],

    searchProps: ["test search prop 1", "test search prop 2"],
    defaultSelectedSearchProp: "Id",
    selectedSearchProp: "Id",
    searchTerm: "test search term",

    changeProps: ["test change prop 1", "test change prop 2"],
    defaultSelectedChangeProp: "Id",
    selectedChangeProp: "Id",
    changePropValue: "test change prop value",
    selectedDataItems: []
  },

  testReducer: {
    test: "testText"
  }
};
