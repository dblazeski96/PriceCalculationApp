import { ITestState } from "../reduxStore/IState";
import { initialState } from "../reduxStore/initialState";
import { Action, Reducer } from "redux";
import { SHOW_RIKI_TEXT } from "../reduxActions/actionTypes";
import { IShowRikiText } from "../reduxActions/IActions";

export const testReducer: Reducer<ITestState> = (
  state: ITestState = initialState.testReducer,
  action: Action<string>
): ITestState => {
  switch (action.type) {
    case SHOW_RIKI_TEXT: {
      const nextState = { ...state };
      nextState.rikiText = (action as IShowRikiText).rikiText;

      return nextState;
    }

    default: {
      return state;
    }
  }
};
