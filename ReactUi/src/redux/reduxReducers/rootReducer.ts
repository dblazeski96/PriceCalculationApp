import { combineReducers, Reducer, AnyAction } from "redux";
import { IState } from "../reduxStore/IState";
import { searchScreenReducer } from "./searchScreenReducer";
import { testReducer } from "./testReducer";

export const rootReducer: Reducer<IState, AnyAction> = combineReducers({
  searchScreenReducer,
  testReducer
});
