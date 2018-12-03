import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "src/redux/store/IState";
import { updateIsOnSearchScreen } from "src/redux/actions/commonActions/commonActionCreators";

import SearchScreenComponent from "src/screens/SearchScreenComponent";

const mapStateToProps = (state: IReduxState) => ({
  selectedItem: state.commonState.selectedItem,
  searchTerm: state.commonState.searchTerm
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateIsOnSearchScreen: (isOnSearchScreen: boolean) => {
    dispatch(updateIsOnSearchScreen(isOnSearchScreen));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchScreenComponent);
