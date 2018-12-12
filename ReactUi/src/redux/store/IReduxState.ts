import { Item } from "src/models/DataModels/Item";

export interface IReduxState {
  mainState: IMainState;
  searchScreenState: ISearchScreenState;
}

export interface IMainState {
  loggedIn: boolean;
  isOnSearchScreen: boolean;
}

export interface ISearchScreenState {
  selectedItem: Item;
  selectedSearchProp: string;
  searchTerm: string;
}
