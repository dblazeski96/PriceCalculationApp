import * as React from "react";

import Grid from "@material-ui/core/Grid";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import LoginForm from "../containers/LoginScreenContainers/LoginForm";

// IProps
interface IProps extends WithStyles<typeof styles> {}

// Component
const LoginScreen = ({ classes }: IProps) => (
  <div>
    <Grid container={true} justify="center" alignItems="center">
      <Grid item={true} xs={10} sm={6} md={4} lg={3}>
        <LoginForm />
      </Grid>
    </Grid>
  </div>
);

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(LoginScreen);
