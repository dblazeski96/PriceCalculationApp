import { Action } from "redux";

export interface IUpdateLoginStatus extends Action<string> {
  loggedIn: boolean;
}

export interface IUpdateIsOnSearchScreen extends Action<string> {
  isOnSearchScreen: boolean;
}
