import * as React from "react";
import { Dispatch, AnyAction } from "redux";
import { connect } from "react-redux";

import { IState } from "src/redux/store/IState";

import { updateSelectedItem } from "src/redux/actions/actions";
import { getAllBusinessItems } from "src/services/BusinessItemService";

import { SelectItemComponent } from "../../components/TableComponents/SelectItemComponent";
import { getAllBusinessEntities } from "src/services/BusinessEntityService";

const mapStateToProps = (state: IState) => ({
  defaultSelectedItem: state.searchScreenReducer.defaultSelectedItem
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleOnChangeItem: (event: React.ChangeEvent<HTMLSelectElement>): void => {
    const selectedItem = event.target.value;

    switch (selectedItem) {
      case "businessItem": {
        getAllBusinessItems().then(res =>
          dispatch(updateSelectedItem(selectedItem, res.data))
        );
      }

      case "businessEntity": {
        getAllBusinessEntities().then(res =>
          dispatch(updateSelectedItem(selectedItem, res.data))
        );
      }

      default:
    }
  }
});

export const SelectItem = connect(
  mapStateToProps,
  mapDispatchToProps
)(SelectItemComponent);
