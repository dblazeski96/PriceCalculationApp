import { IReduxState } from "./IReduxState";
import { Item } from "src/models/DataModels/Item";

const initialReduxState: IReduxState = {
  mainState: {
    loggedIn: true,
    isOnSearchScreen: false
  },
  searchScreenState: {
    selectedItem: Item.businessItem,
    selectedSearchProp: "Id",
    searchTerm: ""
  }
};

export default initialReduxState;
