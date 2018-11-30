import { createStore, combineReducers } from "redux";

import commonState from "../reduxReducers/commonReducer";
import searchScreenState from "../reduxReducers/searchScreenReducer";

const rootReducer = combineReducers({
  commonState,
  searchScreenState
});

export default createStore(rootReducer);
