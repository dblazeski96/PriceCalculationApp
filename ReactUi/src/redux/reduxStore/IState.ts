import { IBaseModel } from "src/models/BaseModel/IBaseModel";

export interface IState {
  searchScreenReducer: ISearchScreenState;
  commonReducer: ICommonState;
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

export interface ICommonState {
  loggedIn: boolean;
}
