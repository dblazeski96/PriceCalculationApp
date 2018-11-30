import { Action } from "redux";

export interface IUpdateLoginStatus extends Action<string> {
  loggedIn: boolean;
}

export interface IUpdateIsOnSearchScreen extends Action<string> {
  isOnSearchScreen: boolean;
}

export interface IUpdateSelectedItem extends Action<string> {
  selectedItem: string;
}

export interface IUpdateSearchTerm extends Action<string> {
  searchTerm: string;
}
