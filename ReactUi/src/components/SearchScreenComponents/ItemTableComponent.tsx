import * as React from "react";

import Paper from "@material-ui/core/Paper";
import Toolbar from "@material-ui/core/Toolbar";
import Table from "@material-ui/core/Table";
import TableHead from "@material-ui/core/TableHead";
import TableBody from "@material-ui/core/TableBody";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import TextField from "@material-ui/core/TextField";
import OutlinedInput from "@material-ui/core/OutlinedInput";
import Button from "@material-ui/core/Button";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import { Item } from "src/models/DataModels/Item";
import { IBaseModel } from "src/models/DataModels/IBaseModel";

import { casingToRender } from "src/services/valueService";

import ItemSelect from "./ItemSelectComponent";

// IProps
interface IProps extends WithStyles<typeof styles> {
  selectedItem: Item;
  itemData: IBaseModel[] | null;
  itemProps: string[] | null;
  shouldFetch: boolean;
  isFetching: boolean;

  updateSelectedItem: (selectedItem: Item) => void;
  updateSelectedSearchProp: (selectedSearchProp: string) => void;
  updateSearchTerm: (searchTerm: string) => void;
  updateShouldFetch: (shouldFetch: boolean) => void;
}

// Component
class ItemTableComponent extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
  }

  // Render
  public render() {
    const {
      classes,
      selectedItem,
      itemData,
      itemProps,
      shouldFetch,
      isFetching,
      updateSelectedItem,
      updateSelectedSearchProp,
      updateSearchTerm,
      updateShouldFetch
    } = this.props;

    return (
      <Paper className={classes.root}>
        <Toolbar>
          <FormControl className={classes.formContainer}>
            <ItemSelect
              selectedItem={selectedItem}
              shouldFetch={shouldFetch}
              isFetching={isFetching}
              updateSelectedItem={updateSelectedItem}
              updateSelectedSearchProp={updateSelectedSearchProp}
              updateSearchTerm={updateSearchTerm}
              updateShouldFetch={updateShouldFetch}
              className={classes.formItem}
            />
            <div className={classes.grow} />
            <Select
              input={<OutlinedInput labelWidth={0} />}
              className={classes.formItem}
            >
              <MenuItem>Test</MenuItem>
            </Select>
            <TextField
              variant="outlined"
              placeholder="Enter value..."
              className={classes.formItem}
            />
            <Button variant="outlined" className={classes.formItem}>
              Change
            </Button>
          </FormControl>
        </Toolbar>

        <Table className={classes.table}>
          {itemProps && (
            <TableHead>
              <TableRow>
                {(casingToRender(itemProps) as string[]).map(i => (
                  <TableCell key={i}>{i.toUpperCase()}</TableCell>
                ))}
              </TableRow>
            </TableHead>
          )}

          {itemData && (
            <TableBody>
              {itemData.map((item, itemIndex) => (
                <TableRow key={itemIndex}>
                  {itemProps &&
                    itemProps.map(key => (
                      <TableCell key={`${itemIndex}-${key}`}>
                        {item[key]}
                      </TableCell>
                    ))}
                </TableRow>
              ))}
            </TableBody>
          )}
        </Table>
      </Paper>
    );
  }
}

// Styles
const styles = (theme: Theme) =>
  createStyles({
    root: {
      margin: theme.spacing.unit * 0.4,
      overflow: "auto"
    },
    grow: {
      flexGrow: 1
    },
    formContainer: {
      width: "100%",
      flexDirection: "row"
    },
    formItem: {
      minWidth: theme.spacing.unit * 26,
      maxHeight: theme.spacing.unit * 5,
      margin: theme.spacing.unit * 0.2
    },
    table: {
      minWidth: 480
    }
  });

export default withStyles(styles)(ItemTableComponent);
