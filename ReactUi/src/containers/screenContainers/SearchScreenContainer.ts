import { Dispatch } from "redux";
import { connect } from "react-redux";

import { IReduxState } from "src/redux/store/IReduxState";
import { updateIsOnSearchScreen } from "src/redux/actions/mainActions/mainActionCreators";
import {
  updateSelectedItem,
  updateSelectedSearchProp,
  updateSearchTerm
} from "src/redux/actions/searchScreenActions/searchScreenActionCreators";

import { Item } from "src/models/DataModels/Item";

import SearchScreenComponent from "src/screens/SearchScreenComponent";

const mapStateToProps = (state: IReduxState) => ({
  selectedItem: state.searchScreenState.selectedItem,
  selectedSearchProp: state.searchScreenState.selectedSearchProp,
  searchTerm: state.searchScreenState.searchTerm
});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateIsOnSearchScreen: (isOnSearchScreen: boolean) => {
    dispatch(updateIsOnSearchScreen(isOnSearchScreen));
  },

  updateSelectedItem: (selectedItem: Item) => {
    dispatch(updateSelectedItem(selectedItem));
  },
  updateSelectedSearchProp: (selectedSearchProp: string) => {
    dispatch(updateSelectedSearchProp(selectedSearchProp));
  },
  updateSearchTerm: (searchTerm: string) => {
    dispatch(updateSearchTerm(searchTerm));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchScreenComponent);
