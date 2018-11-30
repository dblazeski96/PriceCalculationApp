import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "src/redux/reduxStore/IState";
import {
  updateLoginStatus,
  updateSearchTerm
} from "../redux/reduxActions/commonActions/commonActionCreators";

import MenuBarComponent from "src/components/MenuBarComponent";

const mapStateToProps = (state: IReduxState) => ({
  loggedIn: state.commonState.loggedIn,
  isOnSearchScreen: state.commonState.isOnSearchScreen,
  searchTerm: state.commonState.searchTerm
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateLoginStatus: (loggedIn: boolean) => {
    dispatch(updateLoginStatus(loggedIn));
  },
  updateSearchTerm: (searchTerm: string) => {
    dispatch(updateSearchTerm(searchTerm));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(MenuBarComponent);
