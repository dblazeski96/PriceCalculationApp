import { Dispatch, AnyAction } from "redux";
import { ChangeEvent } from "react";
import { connect } from "react-redux";

import { IState } from "src/redux/reduxStore/IState";

import {
  updateSelectedSearchProp,
  updateSearchTerm,
  updateSelectedItem
} from "src/redux/reduxActions/actions";

import { SearchComponent } from "src/components/SearchScreenComponents/SearchComponent";
import { determineDataItemPromise } from "src/services/DetermineDataItemPromise";
import { searchServiceAction } from "src/services/serviceActions/actions";

const mapStateToProps = (state: IState) => ({
  searchProps: state.searchScreenReducer.searchProps,
  defaultSelectedProp: state.searchScreenReducer.defaultSelectedSearchProp,

  selectedItem: state.searchScreenReducer.selectedItem,
  selectedSearchProp: state.searchScreenReducer.selectedSearchProp,
  searchTerm: state.searchScreenReducer.searchTerm
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  updateSearchTerm: (event: React.FormEvent<HTMLInputElement>): void => {
    const value = event.currentTarget.value;
    dispatch(updateSearchTerm(value));
  },

  handleOnChangeProp: (event: ChangeEvent<HTMLSelectElement>): void => {
    dispatch(updateSelectedSearchProp(event.target.value));
  },

  handleSearch: (
    selectedItem: string,
    selectedSearchProp: string,
    searchTerm: string
  ) => (event: React.MouseEvent<HTMLButtonElement>): void => {
    determineDataItemPromise(
      selectedItem,
      searchServiceAction(selectedSearchProp, searchTerm)
    ).then(res => dispatch(updateSelectedItem(selectedItem, res.data)));
  }
});

export const Search = connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchComponent);
