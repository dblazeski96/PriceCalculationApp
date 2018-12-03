import { IReduxState } from "./IState";

const initialState: IReduxState = {
  commonState: {
    loggedIn: true,
    isOnSearchScreen: false,
    selectedItem: "businessItem",
    searchTerm: ""
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
