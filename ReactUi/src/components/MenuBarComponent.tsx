import * as React from "react";

import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import Button from "@material-ui/core/Button";
import Menu from "@material-ui/core/Menu";
import MenuItem from "@material-ui/core/MenuItem";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import EuroSymbol from "@material-ui/icons/EuroSymbol";
import AccountCircle from "@material-ui/icons/AccountCircle";

import {
  ToLandingScreen,
  ToSearchScreen,
  ToPricingScreen,
  ToAdministrationScreen,
  ToLoginScreen,
  ToProfileScreen
} from "./Links";

// Props
interface IProps extends WithStyles<typeof styles> {
  loggedIn: boolean;

  updateLoginStatus: (loggedIn: boolean) => void;
}

// State
interface IState {
  profileAnchorEl: HTMLElement | null;
}

// Styles
const styles = (theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1
    },
    grow: {
      flexGrow: 1
    }
  });

// Component
class MenuBarComponent extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = {
      profileAnchorEl: null
    };

    this.handleProfileClick = this.handleProfileClick.bind(this);
    this.handleProfileMenuClose = this.handleProfileMenuClose.bind(this);
    this.handleLogout = this.handleLogout.bind(this);
  }

  public render() {
    const { loggedIn, classes } = this.props;
    const { profileAnchorEl } = this.state;

    return (
      <AppBar className={classes.root} position="sticky">
        <Toolbar variant="regular">
          <IconButton component={ToLandingScreen} color="inherit">
            <EuroSymbol />
          </IconButton>

          {loggedIn && (
            <div>
              <Button component={ToSearchScreen} color="inherit">
                Search
              </Button>
              <Button component={ToPricingScreen} color="inherit">
                Pricing
              </Button>
              <Button component={ToAdministrationScreen} color="inherit">
                Administration
              </Button>
            </div>
          )}

          <span className={classes.grow} />

          {loggedIn ? (
            <div>
              <IconButton color="inherit" onClick={this.handleProfileClick}>
                <AccountCircle />
              </IconButton>
              <Menu
                anchorEl={profileAnchorEl}
                open={Boolean(profileAnchorEl)}
                onClose={this.handleProfileMenuClose}
              >
                <MenuItem
                  component={ToProfileScreen}
                  onClick={this.handleProfileMenuClose}
                >
                  Profile
                </MenuItem>

                <MenuItem component={ToLoginScreen} onClick={this.handleLogout}>
                  Logout
                </MenuItem>
              </Menu>
            </div>
          ) : (
            <div>
              <Button component={ToLoginScreen} color="inherit">
                Login
              </Button>
            </div>
          )}
        </Toolbar>
      </AppBar>
    );
  }

  private handleProfileClick(e: React.MouseEvent<HTMLButtonElement>) {
    this.setState({
      profileAnchorEl: e.currentTarget
    });
  }

  private handleProfileMenuClose(e: React.SyntheticEvent) {
    this.setState({
      profileAnchorEl: null
    });
  }

  private handleLogout() {
    this.setState({
      profileAnchorEl: null
    });

    this.props.updateLoginStatus(false);
  }
}

export default withStyles(styles)(MenuBarComponent);
