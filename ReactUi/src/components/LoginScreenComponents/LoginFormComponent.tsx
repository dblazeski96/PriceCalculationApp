import * as React from "react";

import Paper from "@material-ui/core/Paper";

import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";

import EuroSymbol from "@material-ui/icons/EuroSymbol";

import {
  Theme,
  createStyles,
  WithStyles,
  withStyles
} from "@material-ui/core/styles";

import { ToSearchScreen } from "../Links";

// Props
interface IProps extends WithStyles<typeof styles> {
  loggedIn: boolean;

  updateLoginStatus: (
    loggedIn: boolean
  ) => (e: React.MouseEvent<HTMLButtonElement>) => void;
}

// Styles
const styles = (theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
      marginTop: theme.spacing.unit * 10
    },
    formContainer: {
      display: "flex",
      flexDirection: "column"
    },
    formItem: {
      margin: theme.spacing.unit * 3
    }
  });

// Component
const LoginFormComponent = ({
  loggedIn,
  updateLoginStatus,
  classes
}: IProps) => (
  <Paper className={classes.root}>
    <form>
      {!loggedIn ? (
        <div className={classes.formContainer}>
          <Typography align="center" variant="h1">
            <EuroSymbol />
          </Typography>
          <Typography
            className={classes.formItem}
            align="center"
            variant="headline"
          >
            Sign in
          </Typography>
          <TextField
            className={classes.formItem}
            label="Email Address"
            placeholder="Enter your email address"
            type="email"
            required={true}
          />
          <TextField
            className={classes.formItem}
            label="Password"
            placeholder="Enter your password"
            type="password"
            required={true}
          />
          <Button
            className={classes.formItem}
            variant="contained"
            color="primary"
            component={ToSearchScreen}
            onClick={updateLoginStatus(true)}
          >
            Login
          </Button>
        </div>
      ) : (
        <div className={classes.formContainer}>
          <Typography className={classes.formItem}>
            You are already logged in :)
          </Typography>
        </div>
      )}
    </form>
  </Paper>
);

export default withStyles(styles)(LoginFormComponent);
