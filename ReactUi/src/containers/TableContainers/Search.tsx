import { Dispatch, AnyAction } from "redux";
import { FormEvent, ChangeEvent } from "react";
import { connect } from "react-redux";

import { IState } from "src/redux/store/IState";

import {
  updateSelectedSearchProp,
  updateSearchTerm
} from "src/redux/actions/actions";

import { SearchComponent } from "src/components/TableComponents/SearchComponent";

const mapStateToProps = (state: IState) => {
  return {
    searchProps: state.searchScreenReducer.searchProps,
    defaultSelectedProp: state.searchScreenReducer.defaultSelectedSearchProp,
    searchTerm: state.searchScreenReducer.searchTerm
  };
};

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleOnChangeProp: (event: ChangeEvent<HTMLSelectElement>) =>
    dispatch(updateSelectedSearchProp(event.target.value)),

  handleSearch: (event: FormEvent<HTMLInputElement>) =>
    dispatch(updateSearchTerm(event.currentTarget.value))
});

export const Search = connect(
  mapStateToProps,
  mapDispatchToProps
)(SearchComponent);
