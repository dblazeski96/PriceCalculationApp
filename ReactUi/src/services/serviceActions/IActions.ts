import { Action } from "redux";

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
