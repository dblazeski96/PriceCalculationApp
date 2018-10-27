import * as React from "react";

interface IProps {
  defaultSelectedItem: string;

  handleOnChangeItem: (
    event: React.ChangeEvent<HTMLSelectElement> | string
  ) => void;
}

export class SelectItemComponent extends React.Component<IProps> {
  public componentDidMount(): void {
    this.props.handleOnChangeItem(this.props.defaultSelectedItem);
  }

  public render(): React.ReactElement<HTMLSelectElement> {
    return (
      <select
        defaultValue={this.props.defaultSelectedItem}
        onChange={this.props.handleOnChangeItem}
      >
        <option value="businessItem">Business Item</option>
        <option value="businessEntity">Business Entity</option>
      </select>
    );
  }
}
