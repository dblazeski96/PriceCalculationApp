import * as React from "react";

import Grid from "@material-ui/core/Grid";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import LoginForm from "src/components/LoginScreenComponents/LoginFormComponent";

// IProps
interface IProps extends WithStyles<typeof styles> {
  loggedIn: boolean;

  updateLoginStatus: (loggedIn: boolean) => void;
}

// Component
const LoginScreenComponent = ({
  classes,
  loggedIn,
  updateLoginStatus
}: IProps) => (
  <Grid container={true} justify="center" alignItems="center">
    <Grid item={true} xs={10} sm={6} md={4} lg={3}>
      <LoginForm loggedIn={loggedIn} updateLoginStatus={updateLoginStatus} />
    </Grid>
  </Grid>
);

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(LoginScreenComponent);
