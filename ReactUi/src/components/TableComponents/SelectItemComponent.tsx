import * as React from "react";
// import { Component } from "react";

interface IProps {
  handleItemOnChange: (event?: React.ChangeEvent<HTMLSelectElement>) => void;
  setDefaultSelectedItem: (defaultValue: string) => void;
}

export let ItemSelectComponent = ({
  handleItemOnChange,
  setDefaultSelectedItem
}: IProps): JSX.Element => (
  <select onChange={handleItemOnChange} defaultValue="businessItem">
    <option value="businessItem">Business Item</option>
    <option value="businessEntity">Business Entity</option>
    {setDefaultSelectedItem("businessItem")}
  </select>
);
