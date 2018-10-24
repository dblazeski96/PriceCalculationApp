import { combineReducers, Reducer, AnyAction } from "redux";
import { IState } from "../store/IState";
import { searchScreenReducer } from "./searchScreenReducer";
import { testReducer } from "./testReducer";

export const rootReducer: Reducer<IState, AnyAction> = combineReducers({
  searchScreenReducer,
  testReducer
});
