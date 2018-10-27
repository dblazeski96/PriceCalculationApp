import { createStore, Store, AnyAction } from "redux";

import { IState } from "./IState";
import { rootReducer } from "../reduxReducers/rootReducer";

export const store: Store<IState, AnyAction> = createStore(rootReducer);