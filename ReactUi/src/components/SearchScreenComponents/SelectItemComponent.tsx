import * as React from "react";

import Select from "@material-ui/core/Select";
import { MenuItem, InputLabel, FormControl } from "@material-ui/core";

const styles = {
  label: {
    minWidth: 120
  }
};

interface IProps {
  selectedItem: string;
  defaultSelectedItem: string;

  handleOnChangeItem: (
    event: React.ChangeEvent<HTMLSelectElement> | string
  ) => void;
}

export class SelectItemComponent extends React.Component<IProps> {
  public componentDidMount(): void {
    this.props.handleOnChangeItem(this.props.defaultSelectedItem);
  }

  public render() {
    return (
      <form>
        <FormControl style={styles.label}>
          <InputLabel htmlFor="selectItem">Item</InputLabel>
          <Select
            inputProps={{ name: "item", id: "selectItem" }}
            value={this.props.selectedItem}
            onChange={this.props.handleOnChangeItem}
          >
            <MenuItem value="businessItem">Business Item</MenuItem>
            <MenuItem value="businessEntity">Business Entity</MenuItem>
          </Select>
        </FormControl>
      </form>
    );
  }
}
