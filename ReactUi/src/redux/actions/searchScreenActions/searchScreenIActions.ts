import { Action } from "redux";
import { Item } from "src/models/DataModels/Item";

export interface IUpdateSelectedItem extends Action<string> {
  selectedItem: Item;
}

export interface IUpdateSelectedSearchProp extends Action<string> {
  selectedSearchProp: string;
}

export interface IUpdateSearchTerm extends Action<string> {
  searchTerm: string;
}
