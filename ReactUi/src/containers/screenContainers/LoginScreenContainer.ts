import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "src/redux/store/IState";
import { updateLoginStatus } from "src/redux/actions/commonActions/commonActionCreators";

import LoginScreenComponent from "src/screens/LoginScreenComponent";

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
