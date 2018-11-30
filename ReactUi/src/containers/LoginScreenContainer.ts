import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "../redux/reduxStore/IState";
import { updateLoginStatus } from "../redux/reduxActions/commonActions/commonActionCreators";

import LoginScreenComponent from "../screens/LoginScreenComponent";

const mapStateToProps = (state: IReduxState) => ({
  loggedIn: state.commonState.loggedIn
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateLoginStatus: (loggedIn: boolean) => {
    dispatch(updateLoginStatus(loggedIn));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(LoginScreenComponent);
