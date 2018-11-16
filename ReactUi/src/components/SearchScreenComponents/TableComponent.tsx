import * as React from "react";
import { IBaseModel } from "../../models/BaseModel/IBaseModel";
import {
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  Button
} from "@material-ui/core";

// const styles = {
//   table: {
//     border: "6px solid green"
//   },
//   tbody: {
//     border: "4px solid blue"
//   },
//   thead: {
//     border: "5px solid red"
//   },
//   trow: {
//     backgroundColor: "white"
//   },
//   trowSelected: {
//     backgroundColor: "grey"
//   }
// };

const styles = {
  table: {
    minWidth: 700
  }
};

interface IProps {
  data: IBaseModel[];
  itemProps: string[];
  selectedItems: number[];
  selectedItem: string;

  handleSelectDataItem: (
    id: number
  ) => (event: React.MouseEvent<HTMLTableRowElement>) => void;
  handleEditItem: (
    id: number,
    data: IBaseModel[],
    selectedItem: string
  ) => (event: React.MouseEvent<HTMLButtonElement>) => void;
}

export const TableComponent = ({
  data,
  itemProps,
  selectedItems,
  selectedItem
}: IProps) => (
  <Table style={styles.table}>
    <TableHead>
      <TableRow>
        {itemProps.map((prop, index) => (
          <TableCell key={`${prop} - ${index}`}>{prop}</TableCell>
        ))}
      </TableRow>
    </TableHead>

    <TableBody>
      {data.map((i, indexItem) => (
        <TableRow key={`${indexItem}`}>
          {itemProps.map((propName, indexProp) => (
            <TableCell key={`${indexItem} - ${indexProp}`}>
              {i[propName]}
            </TableCell>
          ))}
          <TableCell>
            <Button>Edit</Button>
          </TableCell>
        </TableRow>
      ))}
    </TableBody>
  </Table>
);

// export const TableComponentEx = ({
//   data,
//   itemProps,
//   selectedItems,
//   selectedItem,

//   handleSelectDataItem,
//   handleEditItem
// }: IProps): React.ReactElement<HTMLTableElement> => (
//   <table style={styles.table}>
//     <thead>
//       <tr>
//         {itemProps.map(
//           (propName, index): React.ReactElement<HTMLTableHeaderCellElement> => (
//             <th style={styles.thead} key={`PropId-${index}`}>
//               {propName}
//             </th>
//           )
//         )}
//       </tr>
//     </thead>

//     <tbody>
//       {data.map(
//         (i, indexItem): React.ReactElement<HTMLTableRowElement> => (
//           <tr
//             key={`ItemId-${indexItem}`}
//             onClick={handleSelectDataItem(i.Id)}
//             style={
//               selectedItems.indexOf(i.Id) === -1
//                 ? styles.trow
//                 : styles.trowSelected
//             }
//           >
//             {itemProps.map(
//               (
//                 propName,
//                 indexProp
//               ): React.ReactElement<HTMLTableDataCellElement> => (
//                 <td
//                   style={styles.tbody}
//                   key={`PropValue-${indexItem}:${indexProp}`}
//                 >
//                   {i[propName]}
//                 </td>
//               )
//             )}
//             <td>
//               <button onClick={handleEditItem(i.Id, data, selectedItem)}>
//                 Edit
//               </button>
//             </td>
//           </tr>
//         )
//       )}
//     </tbody>
//   </table>
// );
