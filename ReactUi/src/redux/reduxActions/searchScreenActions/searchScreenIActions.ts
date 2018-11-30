import { Action } from "redux";
import { IBaseModel } from "../../../models/DataModels/IBaseModel";

export interface IUpdateSelectedItem extends Action<string> {
  selectedItem: string;
  data: IBaseModel[];
}

export interface IUpdateSelectedSearchProp extends Action<string> {
  prop: string;
}

export interface IUpdateSearchTerm extends Action<string> {
  searchTerm: string;
}

export interface IUpdateSelectedChangeProp extends Action<string> {
  prop: string;
}

export interface IUpdateChangePropValue extends Action<string> {
  propValue: string;
}

export interface ISelectDeselectDataItem extends Action<string> {
  id: number;
}
