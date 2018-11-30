import { IState } from "./IState";

const initialState: IState = {
  commonState: {
    loggedIn: true,
    isOnSearchScreen: false
  },

  searchScreenState: {
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
  }
};

export default initialState;
