import * as React from "react";
import { IBaseModel } from "../../models/BaseModel/IBaseModel";

interface IProps {
  data: IBaseModel[];
  itemProps: string[];

  handleSelectDataItem: (id: number) => () => void;
}

export const TableComponent = ({
  data,
  itemProps,

  handleSelectDataItem
}: IProps): React.ReactElement<HTMLTableElement> => (
  <table style={styles.table}>
    <thead>
      <tr>
        {itemProps.map(
          (propName, index): React.ReactElement<HTMLTableHeaderCellElement> => (
            <th style={styles.thead} key={`PropId-${index}`}>
              {propName}
            </th>
          )
        )}
      </tr>
    </thead>

    <tbody>
      {data.map(
        (i, indexItem): React.ReactElement<HTMLTableRowElement> => (
          <tr key={`ItemId-${indexItem}`} onClick={handleSelectDataItem(i.Id)}>
            {itemProps.map(
              (
                propName,
                indexProp
              ): React.ReactElement<HTMLTableDataCellElement> => (
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
