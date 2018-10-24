import { Dispatch, AnyAction } from "redux";
import { connect } from "react-redux";

import { IState } from "../../redux/store/IState";

import { TableComponent } from "../../components/TableComponents/TableComponent";
import { selectDeselectDataItem } from "src/redux/actions/actions";

const mapStateToProps = (state: IState) => ({
  data: state.searchScreenReducer.itemData,
  itemProps: state.searchScreenReducer.searchProps
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleSelectDataItem: (id: number) => () =>
    dispatch(selectDeselectDataItem(id))
});

export const Table = connect(
  mapStateToProps,
  mapDispatchToProps
)(TableComponent);
