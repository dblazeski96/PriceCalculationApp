import * as React from "react";

import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import MenuBar from "src/containers/MenuBarContainer";

// IProps
interface IProps extends WithStyles<typeof styles> {}

// Component
const ProfileScreenComponent = ({ classes }: IProps) => (
  <div>
    <MenuBar />

    <Paper>
      <Typography>Profile Screen Placeholder</Typography>
    </Paper>
  </div>
);

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(ProfileScreenComponent);
