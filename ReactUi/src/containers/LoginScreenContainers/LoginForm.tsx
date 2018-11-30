import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IState } from "../../redux/reduxStore/IState";
import { updateLoginStatus } from "../../redux/reduxActions/commonActions/commonActionCreators";

import LoginFormComponent from "../../components/LoginScreenComponents/LoginFormComponent";

const mapStateToProps = (state: IState) => ({
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
)(LoginFormComponent);
