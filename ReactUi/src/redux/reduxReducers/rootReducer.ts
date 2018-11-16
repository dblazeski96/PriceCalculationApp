import { combineReducers, Reducer, AnyAction } from "redux";
import { IState } from "../reduxStore/IState";
import { searchScreenReducer } from "./searchScreenReducer";
import { commonReducer } from "./commonReducer";

export const rootReducer: Reducer<IState, AnyAction> = combineReducers({
  searchScreenReducer,
  commonReducer
});
