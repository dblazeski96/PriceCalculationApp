import * as React from "react";

interface IProps {
  itemProps: string[];
  defaultSelectedProp: string;

  handleOnChangeProp: (event: React.ChangeEvent<HTMLSelectElement>) => void;
}

export const DropDownComponent = ({
  itemProps,
  defaultSelectedProp,

  handleOnChangeProp
}: IProps): React.ReactElement<HTMLSelectElement> => (
  <select defaultValue={defaultSelectedProp} onChange={handleOnChangeProp}>
    {itemProps.map((prop, i) => (
      <option key={`${prop}-${i}`}>{prop}</option>
    ))}
  </select>
);
