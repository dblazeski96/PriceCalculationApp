import * as React from "react";

interface IProps {
  updatePropertyValueFromInput: (
    event: React.FormEvent<HTMLInputElement>
  ) => void;
  itemProps: string[];
  handleOnChangeProps: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  handleOnClickChangeMultipleItems: (
    event: React.MouseEvent<HTMLButtonElement>
  ) => void;
}

export let ChangeMultipleItems = ({
  updatePropertyValueFromInput,
  itemProps,
  handleOnChangeProps,
  handleOnClickChangeMultipleItems
}: IProps): React.ReactElement<HTMLDivElement> => {
  return (
    <div>
      <input
        type="text"
        name="propertyValue"
        id="propertyValue"
        placeholder="Enter Value..."
        defaultValue=""
        onInput={updatePropertyValueFromInput}
      />
      {/* <DataItemPropsComponent
        itemProps={itemProps}
        handleOnChangeProps={handleOnChangeProps}
      /> */}
      <button type="button" onClick={handleOnClickChangeMultipleItems}>
        Change Multiple Items
      </button>
    </div>
  );
};
