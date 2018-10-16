import * as React from "react";
import { IBaseModel } from "src/models/BaseModel/IBaseModel";

interface IProps {
  itemProperties: string[];
  data: IBaseModel[];
  handleCheckItem: (id: number) => () => void;
}

export let TableComponent = ({
  itemProperties,
  data,
  handleCheckItem
}: IProps): JSX.Element => (
  <table style={styles.table}>
    <thead>
      <tr>
        {itemProperties.map(
          (propName, index): JSX.Element => (
            <th style={styles.thead} key={`PropId-${index}`}>
              {propName}
            </th>
          )
        )}
      </tr>
    </thead>

    <tbody>
      {data.map(
        (i, indexItem): JSX.Element => (
          <tr key={`ItemId-${indexItem}`} onClick={handleCheckItem(i.Id)}>
            {itemProperties.map(
              (propName, indexProp): JSX.Element => (
                <td
                  style={styles.tbody}
                  key={`PropValue-${indexItem}:${indexProp}`}
                >
                  {i[propName]}
                </td>
              )
            )}
          </tr>
        )
      )}
    </tbody>
  </table>
);

const styles = {
  table: {
    border: "6px solid green"
  },
  tbody: {
    border: "4px solid blue"
  },
  thead: {
    border: "5px solid red"
  }
};
