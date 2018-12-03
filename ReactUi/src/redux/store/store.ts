import { createStore, combineReducers } from "redux";

import commonState from "../reducers/commonReducer";
import searchScreenState from "../reducers/searchScreenReducer";

const rootReducer = combineReducers({
  commonState,
  searchScreenState
});

export default createStore(rootReducer);
