import { Dispatch, AnyAction } from "redux";
import { connect } from "react-redux";

import { IState } from "../../redux/reduxStore/IState";

import { TableComponent } from "../../components/TableComponents/TableComponent";
import { selectDeselectDataItem } from "src/redux/reduxActions/actions";

const mapStateToProps = (state: IState) => ({
  data: state.searchScreenReducer.itemData,
  itemProps: state.searchScreenReducer.itemProps,
  selectedItems: state.searchScreenReducer.selectedDataItems
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleSelectDataItem: (id: number) => (
    event: React.MouseEvent<HTMLTableRowElement>
  ): void => {
    dispatch(selectDeselectDataItem(id));
  }
});

export const Table = connect(
  mapStateToProps,
  mapDispatchToProps
)(TableComponent);
