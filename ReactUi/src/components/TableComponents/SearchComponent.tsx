import * as React from "react";
import { DropDownComponent } from "./DropDownComponent";

export interface IProps {
  searchProps: string[];
  defaultSelectedProp: string;
  selectedItem: string;
  selectedSearchProp: string;
  searchTerm: string;

  updateSearchTerm: (event: React.FormEvent<HTMLInputElement>) => void;
  handleOnChangeProp: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  handleSearch: (
    selectedProp: string,
    selectedSearchProp: string,
    searchTerm: string
  ) => (event: React.MouseEvent<HTMLButtonElement>) => void;
}

export const SearchComponent = ({
  searchProps,
  defaultSelectedProp,
  selectedItem,
  selectedSearchProp,
  searchTerm,

  updateSearchTerm,
  handleOnChangeProp,
  handleSearch
}: IProps): React.ReactElement<HTMLDivElement> => {
  return (
    <div>
      <input
        type="text"
        defaultValue=""
        placeholder="Search..."
        onInput={updateSearchTerm}
      />

      <DropDownComponent
        itemProps={searchProps}
        defaultSelectedProp={defaultSelectedProp}
        handleOnChangeProp={handleOnChangeProp}
      />

      <button
        onClick={handleSearch(selectedItem, selectedSearchProp, searchTerm)}
      >
        Search
      </button>
    </div>
  );
};
