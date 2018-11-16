import { Action } from "redux";
import { IBaseModel } from "src/models/BaseModel/IBaseModel";

export interface IGetAllServiceAction extends Action<string> {}

export interface ISearchServiceAction extends Action<string> {
  prop: string;
  searchTerm: string;
}

export interface IChangeMultipleItemsAction extends Action<string> {
  prop: string;
  value: string;
  items: number[];
}

export interface IChangeItemAction extends Action<string> {
  item: IBaseModel;
}
