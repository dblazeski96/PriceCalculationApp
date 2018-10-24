import * as React from "react";
import { DropDownComponent } from "./DropDownComponent";

export interface IProps {
  searchProps: string[];
  defaultSelectedProp: string;

  handleOnChangeProp: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  handleSearch: (event: React.FormEvent<HTMLInputElement>) => void;
}

export const SearchComponent = ({
  searchProps,
  defaultSelectedProp,

  handleSearch,
  handleOnChangeProp
}: IProps): React.ReactElement<HTMLDivElement> => {
  return (
    <div>
      <input
        type="text"
        defaultValue=""
        placeholder="Search..."
        onInput={handleSearch}
      />
      <DropDownComponent
        itemProps={searchProps}
        defaultSelectedProp={defaultSelectedProp}
        handleOnChangeProp={handleOnChangeProp}
      />
    </div>
  );
};
