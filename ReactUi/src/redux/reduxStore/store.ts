import { createStore, Store } from "redux";

import { IState } from "./IState";
import { rootReducer } from "../reduxReducers/rootReducer";

export const store: Store<IState> = createStore(rootReducer);
