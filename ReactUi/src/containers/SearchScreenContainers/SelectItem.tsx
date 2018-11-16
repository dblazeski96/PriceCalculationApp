import * as React from "react";
import { Dispatch, AnyAction } from "redux";
import { connect } from "react-redux";

import { IState } from "src/redux/reduxStore/IState";

import { updateSelectedItem } from "src/redux/reduxActions/actions";

import { SelectItemComponent } from "../../components/SearchScreenComponents/SelectItemComponent";
import { determineDataItemPromise } from "src/services/DetermineDataItemPromise";
import { getAllServiceAction } from "src/services/serviceActions/actions";

const mapStateToProps = (state: IState) => ({
  selectedItem: state.searchScreenReducer.selectedItem,
  defaultSelectedItem: state.searchScreenReducer.defaultSelectedItem
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleOnChangeItem: (
    event: React.ChangeEvent<HTMLSelectElement> | string
  ): void => {
    const selectedItem = typeof event === "string" ? event : event.target.value;

    determineDataItemPromise(selectedItem, getAllServiceAction()).then(res => {
      dispatch(updateSelectedItem(selectedItem, res.data));
    });
  }
});

export const SelectItem = connect(
  mapStateToProps,
  mapDispatchToProps
)(SelectItemComponent);
