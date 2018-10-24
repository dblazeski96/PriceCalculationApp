import { ITestState } from "../store/IState";
import { initialState } from "../store/initialState";
import { Action, Reducer } from "redux";

export const testReducer: Reducer<ITestState> = (
  state: ITestState = initialState.testReducer,
  action: Action<string>
): ITestState => {
  switch (action.type) {
    case "Test": {
      return { ...state };
    }

    default: {
      return state;
    }
  }
};
