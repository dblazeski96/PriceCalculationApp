import { IBaseModel } from "src/models/BaseModel/IBaseModel";

export interface IState {
  searchScreenReducer: ISearchScreenState;
  testReducer: ITestState;
}

export interface ISearchScreenState {
  defaultSelectedItem: string;
  selectedItem: string;
  itemData: IBaseModel[]; // IBaseModel[]

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

export interface ITestState {
  test: string;
}
