import * as React from "react";

import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import OutlinedInput from "@material-ui/core/OutlinedInput";

import { Item } from "src/models/DataModels/Item";

// IProps
interface IProps {
  selectedItem: Item;
  shouldFetch: boolean;
  isFetching: boolean;

  className: any;

  updateSelectedItem: (selectedItem: Item) => void;
  updateSelectedSearchProp: (selectedSearchProp: string) => void;
  updateSearchTerm: (searchTerm: string) => void;
  updateShouldFetch: (shouldFetch: boolean) => void;
}

// Component
class ItemSelect extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);

    this.handleChangeItem = this.handleChangeItem.bind(this);
  }

  // Render
  public render() {
    const { selectedItem, className } = this.props;

    return (
      <Select
        value={selectedItem}
        input={<OutlinedInput labelWidth={0} />}
        className={className}
        onChange={this.handleChangeItem}
      >
        <MenuItem button={true} value={Item.businessItem}>
          Business Item
        </MenuItem>
        <MenuItem button={true} value={Item.businessEntity}>
          Business Entity
        </MenuItem>
      </Select>
    );
  }

  private handleChangeItem(e: React.ChangeEvent<HTMLSelectElement>) {
    const selectedItem = parseInt(e.target.value, undefined) as Item;
    const {
      shouldFetch,
      isFetching,
      updateSelectedItem,
      updateSelectedSearchProp,
      updateSearchTerm,
      updateShouldFetch
    } = this.props;

    updateSelectedItem(selectedItem);
    updateSelectedSearchProp("Id");
    updateSearchTerm("");

    if (!shouldFetch && !isFetching) {
      updateShouldFetch(true);
    } else {
      updateShouldFetch(false);
    }
  }
}

export default ItemSelect;
