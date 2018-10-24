// import * as React from "react";
// import { Component } from "react";

// import { ChangeMultipleItems } from "src/components/TableComponents/ChangePropertyOfMultipleItems";
// import { ItemSelectComponent } from "../components/TableComponents/SelectItemComponent";
// import { TableComponent } from "../components/TableComponents/TableComponent";
// import { IBaseModel } from "../models/BaseModel/IBaseModel";
// import { getAllBusinessEntities } from "../services/BusinessEntityService";
// import {
//   changePropertyOfMultipleBusinessItems,
//   getAllBusinessItems
// } from "../services/BusinessItemService";
// import { store } from "src/redux/store/store";
// import { updateSearchTerm } from "src/redux/actions/actions";

// interface IState {
//   data: IBaseModel[];
//   dataItemProperties: string[];
//   dataMatch: IBaseModel[];

//   selectedSearchItemProp?: string;
//   selectedChangeitemProp?: string;
//   selectedItems: number[];

//   multiplePropsValue: string;
//   multipleItemsProp: string;

//   searchTerm: string;
// }

// export class Table extends Component<{}, IState> {
//   public constructor(props: any) {
//     super(props);

//     this.state = {
//       data: [],
//       dataItemProperties: [],
//       dataMatch: [],
//       multipleItemsProp: "",
//       multiplePropsValue: "",
//       selectedChangeitemProp: undefined,
//       selectedItems: [],
//       selectedSearchItemProp: undefined,

//       searchTerm: " --- test"
//     };

//     this.handleItemOnChange = this.handleItemOnChange.bind(this);
//     this.handleSelectDataItem = this.handleSelectDataItem.bind(this);
//     this.handleSearch = this.handleSearch.bind(this);
//     this.handleOnChangeSearchItemProps = this.handleOnChangeSearchItemProps.bind(
//       this
//     );
//     this.handleOnChangeChangeItemProps = this.handleOnChangeChangeItemProps.bind(
//       this
//     );
//     this.updatePropertyValueFromInput = this.updatePropertyValueFromInput.bind(
//       this
//     );
//     this.handleOnChangeProps = this.handleOnChangeProps.bind(this);
//     this.handleOnClickChangeMultipleItems = this.handleOnClickChangeMultipleItems.bind(
//       this
//     );
//   }

//   public componentDidMount() {
//     this.handleItemOnChange(undefined);
//   }

//   public render() {
//     return (
//       <div>
//         {this.state.selectedItems.map(
//           (i): JSX.Element => (
//             <p key={i}>{i}</p>
//           )
//         )}
//         {store.getState().searchScreenReducer.searchScreenState.searchTerm}
//         {this.state.searchTerm}
//         <ItemSelectComponent handleItemOnChange={this.handleItemOnChange} />
//         {/* <SearchComponent
//           selectedItemProps={this.state.dataItemProperties}
//           handleSearch={this.handleSearch}
//           handleOnChangeSelectedItemPropsSearch={
//             this.handleOnChangeSearchItemProps
//           }
//         /> */}

//         <TableComponent
//           dataItemProperties={this.state.dataItemProperties}
//           data={this.state.dataMatch}
//           handleSelectDataItem={this.handleSelectDataItem}
//         />
//         <ChangeMultipleItems
//           updatePropertyValueFromInput={this.updatePropertyValueFromInput}
//           itemProps={this.state.dataItemProperties}
//           handleOnChangeProps={this.handleOnChangeProps}
//           handleOnClickChangeMultipleItems={
//             this.handleOnClickChangeMultipleItems
//           }
//         />
//         {this.state.multiplePropsValue}
//         {this.state.multipleItemsProp}
//       </div>
//     );
//   }

//   private handleOnClickChangeMultipleItems(
//     event: React.MouseEvent<HTMLButtonElement>
//   ): void {
//     changePropertyOfMultipleBusinessItems(
//       this.state.multipleItemsProp,
//       this.state.multiplePropsValue,
//       this.state.selectedItems
//     );
//   }

//   private handleOnChangeProps(
//     event: React.ChangeEvent<HTMLSelectElement>
//   ): void {
//     this.setState({
//       multipleItemsProp: event.target.value
//     });
//   }

//   private updatePropertyValueFromInput(
//     event: React.FormEvent<HTMLInputElement>
//   ): void {
//     this.setState({
//       multiplePropsValue: event.currentTarget.value
//     });
//   }

//   private handleOnChangeSearchItemProps(
//     event: React.ChangeEvent<HTMLSelectElement>
//   ): void {
//     this.setState({
//       selectedSearchItemProp: event.target.value
//     });
//   }

//   private handleOnChangeChangeItemProps(
//     event: React.ChangeEvent<HTMLSelectElement>
//   ): void {
//     this.setState({
//       selectedChangeitemProp: event.target.value
//     });
//   }

//   private handleSearch(event: React.FormEvent<HTMLInputElement>): void {
//     store.dispatch(updateSearchTerm(event.currentTarget.value));
//     this.setState({
//       searchTerm: " --- " + event.currentTarget.value
//     });
//   }

//   private handleSelectDataItem(id: number): () => void {
//     return () =>
//       this.setState({
//         selectedItems:
//           this.state.selectedItems.indexOf(id) === -1
//             ? [...this.state.selectedItems, id]
//             : [...this.state.selectedItems.filter(i => i !== id)]
//       });
//   }

//   private handleItemOnChange(
//     event?: React.ChangeEvent<HTMLSelectElement>,
//     defaultValue: string = "businessItem"
//   ): void {
//     const selectedValue = event ? event.target.value : defaultValue;

//     switch (selectedValue) {
//       case "businessItem":
//         getAllBusinessItems().then(res =>
//           this.setState({
//             data: res.data,
//             dataItemProperties: Object.keys(res.data[0]),
//             dataMatch: res.data,
//             selectedItems: []
//           })
//         );
//         break;
//       case "businessEntity":
//         getAllBusinessEntities().then(res => {
//           this.setState({
//             data: res.data,
//             dataItemProperties: Object.keys(res.data[0]),
//             dataMatch: res.data,
//             selectedItems: []
//           });
//         });
//         break;
//       default:
//         alert(`"${selectedValue}" is invalid item!`);
//     }
//   }
// }
