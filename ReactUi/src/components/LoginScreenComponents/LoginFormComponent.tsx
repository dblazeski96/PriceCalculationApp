import * as React from "react";
import Axios from "axios";

import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";
import TextField from "@material-ui/core/TextField";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Switch from "@material-ui/core/Switch";
import Button from "@material-ui/core/Button";
import LinearProgress from "@material-ui/core/LinearProgress";

import AccountCircle from "@material-ui/icons/AccountCircleRounded";

import {
  Theme,
  createStyles,
  WithStyles,
  withStyles
} from "@material-ui/core/styles";

import { RedirectToSearchScreen } from "../../components/Redirect";

// Props
interface IProps extends WithStyles<typeof styles> {
  loggedIn: boolean;

  updateLoginStatus: (loggedIn: boolean) => void;
}

// State
interface IState {
  values: IValues;
  errors: IErrors;
}

interface IValues {
  email: {
    value: string;
    touched: boolean;
  };
  password: {
    value: string;
    touched: boolean;
  };
  rememberMe: boolean;
  isFetching: boolean;
}

interface IErrors {
  email: string;
  password: string;
  fetchError: string;
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
    },
    logo: {
      marginBottom: theme.spacing.unit
    },
    emailField: {
      marginTop: theme.spacing.unit,
      marginBottom: theme.spacing.unit
    },
    passwordField: {
      marginTop: theme.spacing.unit,
      marginBottom: theme.spacing.unit
    },
    switchButton: {
      margin: theme.spacing.unit
    }
  });

// Component
class LoginFormComponent extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = {
      values: {
        email: {
          value: "",
          touched: false
        },
        password: {
          value: "",
          touched: false
        },
        rememberMe: false,
        isFetching: false
      },
      errors: {
        email: "",
        password: "",
        fetchError: ""
      }
    };

    this.handleEmailOnBlur = this.handleEmailOnBlur.bind(this);
    this.handlePasswordOnBlur = this.handlePasswordOnBlur.bind(this);

    this.updateEmail = this.updateEmail.bind(this);
    this.updatePassword = this.updatePassword.bind(this);
    this.updateRememberMe = this.updateRememberMe.bind(this);
    this.tryLogin = this.tryLogin.bind(this);
  }

  public render() {
    const { classes, loggedIn } = this.props;
    const { values, errors } = this.state;

    return (
      <Paper className={classes.root}>
        {loggedIn && <RedirectToSearchScreen />}

        {!loggedIn && (
          <form className={classes.formContainer}>
            {values.isFetching && <LinearProgress variant="indeterminate" />}
            {!values.isFetching && (
              <LinearProgress variant="determinate" value={0} />
            )}
            <Typography
              className={[classes.formItem, classes.logo].join(" ")}
              align="center"
            >
              <AccountCircle fontSize="large" color="primary" />
            </Typography>

            <Typography align="center" variant="headline">
              Log in
            </Typography>

            <TextField
              className={[classes.formItem, classes.emailField].join(" ")}
              type="email"
              required={true}
              error={Boolean(errors.email)}
              value={values.email.value}
              label="Email"
              placeholder="Enter your email address"
              helperText={` ${errors.email}`}
              onChange={this.updateEmail}
              onBlur={this.handleEmailOnBlur}
            />

            <TextField
              className={[classes.formItem, classes.passwordField].join(" ")}
              type="password"
              required={true}
              error={Boolean(errors.password)}
              value={values.password.value}
              label="Password"
              placeholder="Enter your password"
              helperText={` ${errors.password}`}
              onChange={this.updatePassword}
              onBlur={this.handlePasswordOnBlur}
            />

            <FormControlLabel
              className={classes.switchButton}
              control={
                <Switch
                  checked={values.rememberMe}
                  onChange={this.updateRememberMe}
                />
              }
              label="Remember me"
            />

            <Button
              className={classes.formItem}
              variant="contained"
              color="primary"
              onClick={this.tryLogin}
            >
              Login
            </Button>
          </form>
        )}
      </Paper>
    );
  }

  private validateEmail(email: string) {
    switch (true) {
      case email === "":
        return "Required *";
      case !email.includes("@"):
        return "Please enter a valid email address";
      default:
        return "";
    }
  }

  private validatePassword(password: string) {
    switch (true) {
      case password === "":
        return "Required *";
      case password.length < 8:
        return "Your password must be at least 8 characters long";
      default:
        return "";
    }
  }

  private handleEmailOnBlur(e: any) {
    const values = this.state.values;
    const { value } = this.state.values.email;
    const errors = this.state.errors;

    values.email.touched = true;
    errors.email = this.validateEmail(value);

    this.setState({
      values,
      errors
    });
  }

  private updateEmail(e: React.ChangeEvent<HTMLInputElement>) {
    const emailValue = e.currentTarget.value;

    const values = this.state.values;
    const { touched } = this.state.values.email;
    const errors = this.state.errors;

    values.email.value = emailValue;
    errors.email = touched ? this.validateEmail(emailValue) : "";

    this.setState({
      values,
      errors
    });
  }

  private handlePasswordOnBlur(e: any) {
    const values = this.state.values;
    const { value } = this.state.values.password;
    const errors = this.state.errors;

    values.password.touched = true;
    errors.password = this.validatePassword(value);

    this.setState({
      values,
      errors
    });
  }

  private updatePassword(e: React.ChangeEvent<HTMLInputElement>) {
    const passwordValue = e.currentTarget.value;

    const values = this.state.values;
    const { touched } = this.state.values.password;
    const errors = this.state.errors;

    values.password.value = passwordValue;
    errors.password = touched ? this.validatePassword(passwordValue) : "";

    this.setState({
      values,
      errors
    });
  }

  private updateRememberMe(e: React.ChangeEvent<HTMLInputElement>) {
    const rememberMe = e.currentTarget.checked;
    const values = this.state.values;

    values.rememberMe = rememberMe;

    this.setState({
      values
    });
  }

  private tryLogin(e: React.MouseEvent<HTMLButtonElement>) {
    const values = this.state.values;
    values.isFetching = true;
    this.setState({
      values
    });

    Axios.get("http://localhost:2888/api/login/requestlogin")
      .then(res => {
        values.isFetching = false;
        this.props.updateLoginStatus(true);

        this.setState({
          values
        });
      })
      .catch(err => {
        const errors = this.state.errors;

        values.isFetching = false;
        errors.fetchError = err;

        this.setState({
          values,
          errors
        });
      });
  }
}

export default withStyles(styles)(LoginFormComponent);
