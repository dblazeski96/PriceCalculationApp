import { IBaseModel } from "src/models/DataModels/IBaseModel";

export interface IReduxState {
  commonState: ICommonState;
  searchScreenState: ISearchScreenState;
}

export interface ICommonState {
  loggedIn: boolean;
  isOnSearchScreen: boolean;
  selectedItem: string;
  searchTerm: string;
}

export interface ISearchScreenState {
  defaultSelectedItem: string;
  selectedItem: string;
  itemData: IBaseModel[];
  itemProps: string[];

  searchProps: string[];
  defaultSelectedSearchProp: string;
  selectedSearchProp: string;
  searchTerm: string;

  changeProps: string[];
  defaultSelectedChangeProp: string;
  selectedChangeProp: string;
  changePropValue: string;
  selectedDataItems: number[];
}
