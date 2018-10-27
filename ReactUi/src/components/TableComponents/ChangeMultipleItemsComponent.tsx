import * as React from "react";
import { DropDownComponent } from "./DropDownComponent";

interface IProps {
  changeProps: string[];
  defaultSelectedProp: string;
  selectedItem: string;
  changeProp: string;
  changeValue: string;
  changeItems: number[];

  updatePropertyValue: (event: React.FormEvent<HTMLInputElement>) => void;
  handleOnChangeProp: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  handleChangeMultipleItems: (
    selectedItem: string,
    changeProp: string,
    changeValue: string,
    changeItems: number[]
  ) => (event: React.MouseEvent<HTMLButtonElement>) => void;
}

export const ChangeMultipleItemsComponent = ({
  changeProps,
  defaultSelectedProp,
  selectedItem,
  changeProp,
  changeValue,
  changeItems,

  updatePropertyValue,
  handleOnChangeProp,
  handleChangeMultipleItems
}: IProps): React.ReactElement<HTMLDivElement> => {
  return (
    <div>
      <input
        type="text"
        defaultValue=""
        placeholder="Enter Value..."
        onInput={updatePropertyValue}
      />

      <DropDownComponent
        itemProps={changeProps}
        defaultSelectedProp={defaultSelectedProp}
        handleOnChangeProp={handleOnChangeProp}
      />

      <button
        type="button"
        onClick={handleChangeMultipleItems(
          selectedItem,
          changeProp,
          changeValue,
          changeItems
        )}
      >
        Change Multiple Items
      </button>
    </div>
  );
};
