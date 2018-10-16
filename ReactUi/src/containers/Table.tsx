import * as React from "react";
import { Component } from "react";

import { SearchComponent } from "../components/TableComponents/SearchComponent";
import { ItemSelectComponent } from "../components/TableComponents/SelectItemComponent";
import { TableComponent } from "../components/TableComponents/TableComponent";
import { IBaseModel } from "../models/BaseModel/IBaseModel";
import { getAllBusinessEntities } from "../services/BusinessEntityService";
import { getAllBusinessItems } from "../services/BusinessItemService";

interface IState {
  itemProperties: string[];
  data: IBaseModel[];
  selectedItems: number[];
  renderFirstTime: boolean;
}

export class Table extends Component<{}, IState> {
  public constructor(props: any) {
    super(props);

    this.state = {
      data: [],
      itemProperties: [],
      renderFirstTime: true,
      selectedItems: []
    };

    this.handleItemOnChange = this.handleItemOnChange.bind(this);
    this.handleSelect = this.handleSelect.bind(this);
    this.setDefaultSelectedItem = this.setDefaultSelectedItem.bind(this);
  }

  public render() {
    return (
      <div>
        {this.state.selectedItems.map(
          (i): JSX.Element => (
            <p key={i}>{i}</p>
          )
        )}
        <SearchComponent selectedItemProps={this.state.itemProperties} />
        <ItemSelectComponent
          handleItemOnChange={this.handleItemOnChange}
          setDefaultSelectedItem={this.setDefaultSelectedItem}
        />
        <TableComponent
          itemProperties={this.state.itemProperties}
          data={this.state.data}
          handleCheckItem={this.handleSelect}
        />
      </div>
    );
  }

  private setDefaultSelectedItem(defaultValue: string): void {
    if (this.state.renderFirstTime) {
      this.setState({
        renderFirstTime: false
      });
      this.handleItemOnChange(undefined, defaultValue);
    }
  }

  private handleSelect(id: number): () => void {
    return () =>
      this.setState({
        selectedItems:
          this.state.selectedItems.indexOf(id) === -1
            ? [...this.state.selectedItems, id]
            : [...this.state.selectedItems.filter(i => i !== id)]
      });
  }

  private handleItemOnChange(
    event?: React.ChangeEvent<HTMLSelectElement>,
    defaultValue?: string
  ): void {
    const selectedValue = event ? event.target.value : defaultValue;

    switch (selectedValue) {
      case "businessItem":
        getAllBusinessItems().then(res =>
          this.setState({
            data: res.data,
            itemProperties: Object.keys(res.data[0]),
            selectedItems: []
          })
        );
        break;
      case "businessEntity":
        getAllBusinessEntities().then(res => {
          this.setState({
            data: res.data,
            itemProperties: Object.keys(res.data[0]),
            selectedItems: []
          });
        });
        break;
      default:
        alert(`"${selectedValue}" is invalid item!`);
    }
  }
}
