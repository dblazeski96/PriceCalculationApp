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

import MenuIcon from "@material-ui/icons/Menu";
import EuroSymbol from "@material-ui/icons/EuroSymbol";
import AccountCircle from "@material-ui/icons/AccountCircle";
import FilterVintage from "@material-ui/icons/FilterVintage";
import PowerSettingsNew from "@material-ui/icons/PowerSettingsNew";

import {
  ToLandingScreen,
  ToSearchScreen,
  ToPricingScreen,
  ToAdministrationScreen,
  ToLoginScreen,
  ToProfileScreen
} from "./Links";
import {
  ListItemIcon,
  ListItemText,
  Drawer,
  Divider,
  List,
  ListItem,
  Typography
} from "@material-ui/core";

// Props
interface IProps extends WithStyles<typeof styles> {
  loggedIn: boolean;

  updateLoginStatus: (loggedIn: boolean) => void;
}

// State
interface IState {
  profileAnchorEl: HTMLElement | null;
  drawerOpen: boolean;
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
      profileAnchorEl: null,
      drawerOpen: false
    };

    this.openCloseDrawer = this.openCloseDrawer.bind(this);

    this.handleProfileClick = this.handleProfileClick.bind(this);
    this.handleProfileMenuClose = this.handleProfileMenuClose.bind(this);
    this.handleLogout = this.handleLogout.bind(this);
  }

  public render() {
    const { loggedIn, classes } = this.props;
    const { profileAnchorEl, drawerOpen } = this.state;

    return (
      <div>
        <AppBar className={classes.root} position="sticky">
          <Toolbar variant="regular">
            <IconButton onClick={this.openCloseDrawer}>
              <MenuIcon />
            </IconButton>

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

            {loggedIn && (
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
                    <ListItemIcon>
                      <FilterVintage />
                    </ListItemIcon>
                    <ListItemText primary="Profile" />
                  </MenuItem>

                  <MenuItem
                    component={ToLoginScreen}
                    onClick={this.handleLogout}
                  >
                    <ListItemIcon>
                      <PowerSettingsNew />
                    </ListItemIcon>
                    <ListItemText primary="Logout" />
                  </MenuItem>
                </Menu>
              </div>
            )}
            {!loggedIn && (
              <div>
                <Button component={ToLoginScreen} color="inherit">
                  Login
                </Button>
              </div>
            )}
          </Toolbar>
        </AppBar>
        <Drawer variant="persistent" anchor="left" open={drawerOpen}>
          <List>
            <Typography variant="display1" align="center">
              Menu
            </Typography>
            <Divider />
            <ListItem component={ToSearchScreen} button={true}>
              <ListItemText primary="Search" />
            </ListItem>
            <ListItem component={ToPricingScreen} button={true}>
              <ListItemText primary="Pricing" />
            </ListItem>
            <ListItem component={ToAdministrationScreen} button={true}>
              <ListItemText primary="Administration" />
            </ListItem>
          </List>
        </Drawer>
      </div>
    );
  }

  // Handle Drawer
  private openCloseDrawer(e: React.MouseEvent<HTMLButtonElement>) {
    const drawerOpen = !this.state.drawerOpen;
    this.setState({
      drawerOpen
    });
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
