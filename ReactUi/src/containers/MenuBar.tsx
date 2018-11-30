import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IState } from "src/redux/reduxStore/IState";
import { updateLoginStatus } from "../redux/reduxActions/commonActions/commonActionCreators";

import MenuBarComponent from "src/components/MenuBarComponent";

const mapStateToProps = (state: IState) => ({
  loggedIn: state.commonState.loggedIn,
  isOnSearchScreen: state.commonState.isOnSearchScreen
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateLoginStatus: (loggedIn: boolean) => {
    dispatch(updateLoginStatus(loggedIn));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(MenuBarComponent);
