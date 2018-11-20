import { connect } from "react-redux";
import { Dispatch } from "redux";

import { IState } from "../../redux/reduxStore/IState";
import { updateLoginStatus } from "src/redux/reduxActions/actions";

import LoginFormComponent from "../../components/LoginScreenComponents/LoginFormComponent";

const mapStateToProps = (state: IState) => ({
  loggedIn: state.commonReducer.loggedIn
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateLoginStatus: (loggedIn: boolean) => {
    dispatch(updateLoginStatus(loggedIn));
  }
});

export const LoginForm = connect(
  mapStateToProps,
  mapDispatchToProps
)(LoginFormComponent);
