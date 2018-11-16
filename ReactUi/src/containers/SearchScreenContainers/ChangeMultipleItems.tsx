import { ChangeMultipleItemsComponent } from "src/components/SearchScreenComponents/ChangeMultipleItemsComponent";
import { IState } from "src/redux/reduxStore/IState";
import { Dispatch, AnyAction } from "redux";
import { connect } from "react-redux";
import {
  updateChangePropValue,
  updateSelectedChangeProp
} from "src/redux/reduxActions/actions";
import { changeMultipleItemsAction } from "src/services/serviceActions/actions";
import { determineDataItemPromise } from "src/services/DetermineDataItemPromise";

const mapStateToProps = (state: IState) => ({
  changeProps: state.searchScreenReducer.changeProps,
  defaultSelectedProp: state.searchScreenReducer.defaultSelectedChangeProp,
  selectedItem: state.searchScreenReducer.selectedItem,
  changeProp: state.searchScreenReducer.selectedChangeProp,
  changeValue: state.searchScreenReducer.changePropValue,
  changeItems: state.searchScreenReducer.selectedDataItems
});

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>) => ({
  updatePropertyValue: (event: React.FormEvent<HTMLInputElement>) => {
    const value = event.currentTarget.value;
    dispatch(updateChangePropValue(value));
  },
  handleOnChangeProp: (event: React.ChangeEvent<HTMLSelectElement>) => {
    dispatch(updateSelectedChangeProp(event.target.value));
  },
  handleChangeMultipleItems: (
    selectedItem: string,
    changeProp: string,
    changeValue: string,
    changeItems: number[]
  ) => (event: React.MouseEvent<HTMLButtonElement>) => {
    determineDataItemPromise(
      selectedItem,
      changeMultipleItemsAction(changeProp, changeValue, changeItems)
    ).then(res => alert(res.statusText));
  }
});

export const ChangeMultipleItems = connect(
  mapStateToProps,
  mapDispatchToProps
)(ChangeMultipleItemsComponent);
