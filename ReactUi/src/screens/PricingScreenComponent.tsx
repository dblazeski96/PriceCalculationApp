import * as React from "react";

import Grid from "@material-ui/core/Grid";
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
const PricingScreenComponent = ({ classes }: IProps) => (
  <Grid container={true} justify="center" alignItems="center">
    <Grid item={true} xs={12}>
      <MenuBar />
    </Grid>

    <Grid item={true} xs={11}>
      <Paper>
        <Typography align="center">Pricing Screen Placeholder</Typography>
      </Paper>
    </Grid>
  </Grid>
);

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(PricingScreenComponent);
