import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "src/redux/store/IReduxState";
import { updateLoginStatus } from "src/redux/actions/mainActions/mainActionCreators";
import { updateSearchTerm } from "src/redux/actions/searchScreenActions/searchScreenActionCreators";

import MenuBarComponent from "src/components/MenuBarComponent";

const mapStateToProps = (state: IReduxState) => ({
  loggedIn: state.mainState.loggedIn,
  isOnSearchScreen: state.mainState.isOnSearchScreen,

  selectedItem: state.searchScreenState.selectedItem,
  selectedSearchProp: state.searchScreenState.selectedSearchProp,
  searchTerm: state.searchScreenState.searchTerm
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
