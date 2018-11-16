import { ICommonState } from "../reduxStore/IState";
import { initialState } from "../reduxStore/initialState";
import { Action, Reducer } from "redux";
import { UPDATE_LOGIN_STATUS } from "../reduxActions/actionTypes";
import { IUpdateLoginStatus } from "../reduxActions/IActions";

export const commonReducer: Reducer<ICommonState> = (
  state: ICommonState = initialState.commonReducer,
  action: Action<string>
): ICommonState => {
  switch (action.type) {
    case UPDATE_LOGIN_STATUS: {
      const nextState = { ...state };
      nextState.loggedIn = (action as IUpdateLoginStatus).loggedIn;

      return nextState;
    }

    default: {
      return state;
    }
  }
};
