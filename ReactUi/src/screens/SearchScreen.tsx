import * as React from "react";

import CssBaseline from "@material-ui/core/CssBaseline";
import { Paper, Theme } from "@material-ui/core";

import { Search } from "../containers/SearchScreenContainers/Search";
import { SelectItem } from "../containers/SearchScreenContainers/SelectItem";
import { Table } from "../containers/SearchScreenContainers/Table";
import { ChangeMultipleItems } from "src/containers/SearchScreenContainers/ChangeMultipleItems";
import { withStyles } from "@material-ui/core";

// const styles = {
//   root: {
//     width: "90%",
//     overFlowX: "auto"
//   }
// };

const customStyles = (theme: Theme) => ({
  root: {
    ...theme.mixins.gutters()
  }
});

const SearchScreenComponent = ({ classes }: any) => (
  <Paper className={classes.root}>
    <CssBaseline />
    <SelectItem />
    <Search />
    <Table />
    <ChangeMultipleItems />
  </Paper>
);

export const SearchScreen = withStyles(customStyles)(SearchScreenComponent);
