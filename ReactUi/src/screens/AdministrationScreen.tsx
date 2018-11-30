import * as React from "react";

import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import MenuBar from "../containers/MenuBar";

// IProps
interface IProps extends WithStyles<typeof styles> {}

// Component
const AdministrationScreen = ({ classes }: IProps) => (
  <div>
    <MenuBar />

    <Paper>
      <Typography>Administration Screen Placeholder</Typography>
    </Paper>
  </div>
);

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(AdministrationScreen);
