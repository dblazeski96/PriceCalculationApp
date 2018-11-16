import { Dispatch, AnyAction } from "redux";
import { connect } from "react-redux";

import { IState } from "../../redux/reduxStore/IState";

import { TableComponent } from "../../components/SearchScreenComponents/TableComponent";
import { selectDeselectDataItem } from "src/redux/reduxActions/actions";
import { determineDataItemPromise } from "src/services/DetermineDataItemPromise";
import { IBaseModel } from "src/models/BaseModel/IBaseModel";
import { changeItemAction } from "src/services/serviceActions/actions";

const mapStateToProps = (state: IState) => ({
  data: state.searchScreenReducer.itemData,
  itemProps: state.searchScreenReducer.itemProps,
  selectedItems: state.searchScreenReducer.selectedDataItems,
  selectedItem: state.searchScreenReducer.selectedItem
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  handleSelectDataItem: (id: number) => (
    event: React.MouseEvent<HTMLTableRowElement>
  ): void => {
    dispatch(selectDeselectDataItem(id));
  },
  handleEditItem: (id: number, data: IBaseModel[], selectedItem: string) => (
    event: React.MouseEvent<HTMLButtonElement>
  ): void => {
    alert(`Item: ${id}`);
    const item: IBaseModel = data.filter(i => i.Id === id)[0];
    determineDataItemPromise(selectedItem, changeItemAction(item));
  }
});

export const Table = connect(
  mapStateToProps,
  mapDispatchToProps
)(TableComponent);
