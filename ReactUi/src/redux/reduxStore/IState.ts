import { IBaseModel } from "../../models/DataModels/IBaseModel";

export interface IState {
  commonState: ICommonState;
  searchScreenState: ISearchScreenState;
}

export interface ICommonState {
  loggedIn: boolean;
  isOnSearchScreen: boolean;
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
