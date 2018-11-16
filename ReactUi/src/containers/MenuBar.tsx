import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IState } from "src/redux/reduxStore/IState";
import { updateLoginStatus } from "src/redux/reduxActions/actions";

import MenuBarComponent from "src/components/MenuBarComponent";

const mapStateToProps = (state: IState) => ({
  loggedIn: state.commonReducer.loggedIn
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateLoginStatus: (loggedIn: boolean) => {
    dispatch(updateLoginStatus(loggedIn));
  }
});

export const MenuBar = connect(
  mapStateToProps,
  mapDispatchToProps
)(MenuBarComponent);
