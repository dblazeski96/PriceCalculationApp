import { IState } from "./IState";

export const initialState: IState = {
  searchScreenReducer: {
    defaultSelectedItem: "businessItem",
    selectedItem: "businessItem",
    itemData: [],
    itemProps: ["noData"],

    searchProps: ["noData"],
    defaultSelectedSearchProp: "Id",
    selectedSearchProp: "noData",
    searchTerm: "",

    changeProps: ["noData"],
    defaultSelectedChangeProp: "Id",
    selectedChangeProp: "noData",
    changePropValue: "",
    selectedDataItems: []
  },

  commonReducer: {
    loggedIn: false
  }
};
