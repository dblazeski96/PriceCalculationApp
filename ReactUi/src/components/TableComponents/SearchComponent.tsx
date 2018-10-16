import * as React from "react";

interface IProps {
  selectedItemProps: string[];
}

export let SearchComponent = ({ selectedItemProps }: IProps): JSX.Element => (
  <div>
    <input
      type="text"
      name="searchCriteria"
      id="searchCriteria"
      placeholder="Search..."
    />
    <select name="searchByProperty" id="searchByProperty">
      {selectedItemProps.map(
        (i, index): JSX.Element => (
          <option key={`${i + index}`}>{i}</option>
        )
      )}
    </select>
  </div>
);
