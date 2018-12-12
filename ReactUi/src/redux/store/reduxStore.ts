import { createStore, combineReducers } from "redux";

import mainState from "../reducers/mainReducer";
import searchScreenState from "../reducers/searchScreenReducer";

const rootReducer = combineReducers({
  mainState,
  searchScreenState
});

export default createStore(rootReducer);
