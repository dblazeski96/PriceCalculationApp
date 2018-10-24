import * as React from "react";

interface IProps {
  defaultSelectedItem: string;

  handleOnChangeItem: (event: React.ChangeEvent<HTMLSelectElement>) => void;
}

export const SelectItemComponent = ({
  defaultSelectedItem,

  handleOnChangeItem
}: IProps): React.ReactElement<HTMLSelectElement> => (
  <select defaultValue={defaultSelectedItem} onChange={handleOnChangeItem}>
    <option value="businessItem">Business Item</option>
    <option value="businessEntity">Business Entity</option>
  </select>
);
