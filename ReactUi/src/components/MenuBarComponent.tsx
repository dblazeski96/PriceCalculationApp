import * as React from "react";

import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Hidden from "@material-ui/core/Hidden";
import ClickAwayListener from "@material-ui/core/ClickAwayListener";
import Paper from "@material-ui/core/Paper";
import Drawer from "@material-ui/core/Drawer";
import Popper from "@material-ui/core/Popper";
import Divider from "@material-ui/core/Divider";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import MenuList from "@material-ui/core/MenuList";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";
import IconButton from "@material-ui/core/IconButton";
import InputBase from "@material-ui/core/InputBase";

import EuroSymbol from "@material-ui/icons/EuroSymbol";
import MenuIcon from "@material-ui/icons/Menu";
import SearchIcon from "@material-ui/icons/Search";
import AccountCircle from "@material-ui/icons/AccountCircle";
import FilterVintage from "@material-ui/icons/FilterVintage";
import PowerSettingsNew from "@material-ui/icons/PowerSettingsNew";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";
import { fade } from "@material-ui/core/styles/colorManipulator";

import {
  ToLandingScreen,
  ToLoginScreen,
  ToProfileScreen,
  ToSearchScreen,
  ToPricingScreen,
  ToAdministrationScreen
} from "src/services/componentServices/Links";
import { RedirectToSearchScreen } from "src/services/componentServices/Redirects";
import { Item } from "src/models/DataModels/Item";

// IProps
interface IProps extends WithStyles<typeof styles> {
  loggedIn: boolean;
  isOnSearchScreen: boolean;

  selectedItem: Item;
  selectedSearchProp: string;
  searchTerm: string;

  updateLoginStatus: (loggedIn: boolean) => void;

  updateSearchTerm: (searchTerm: string) => void;
}

// IState
interface IState {
  drawerOpen: boolean;
  shouldSearch: boolean;
  profileAnchorEl: HTMLElement | null;
  profileMenuOpen: boolean;
}

// Component
class MenuBarComponent extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = {
      drawerOpen: false,
      shouldSearch: false,
      profileAnchorEl: null,
      profileMenuOpen: false
    };

    this.handleMenuClick = this.handleMenuClick.bind(this);
    this.handleDrawerClose = this.handleDrawerClose.bind(this);
    this.handleSearchInputChange = this.handleSearchInputChange.bind(this);
    this.handleSearchOnKeyDown = this.handleSearchOnKeyDown.bind(this);
    this.handleSearchOnClick = this.handleSearchOnClick.bind(this);
    this.handleProfileClick = this.handleProfileClick.bind(this);
    this.handleProfileMenuClose = this.handleProfileMenuClose.bind(this);

    this.handleLogout = this.handleLogout.bind(this);
  }

  public componentDidUpdate() {
    const { shouldSearch } = this.state;

    if (shouldSearch) {
      this.setState({
        shouldSearch: false
      });
    }
  }

  public render() {
    const { classes, loggedIn, isOnSearchScreen, searchTerm } = this.props;
    const {
      drawerOpen,
      shouldSearch,
      profileAnchorEl,
      profileMenuOpen
    } = this.state;

    return (
      <AppBar position="sticky" color="primary" className={classes.appBar}>
        {loggedIn && (
          <Toolbar variant="regular">
            {shouldSearch && <RedirectToSearchScreen />}
            <Hidden mdUp={true}>
              <IconButton
                centerRipple={true}
                color="inherit"
                onClick={this.handleMenuClick}
              >
                <MenuIcon />
              </IconButton>
            </Hidden>

            <Hidden smDown={true}>
              <IconButton
                centerRipple={true}
                color="inherit"
                component={ToLandingScreen}
              >
                <EuroSymbol />
              </IconButton>
            </Hidden>

            {!isOnSearchScreen && (
              <div
                className={classes.search}
                onKeyDown={this.handleSearchOnKeyDown}
              >
                <InputBase
                  placeholder="Search…"
                  value={searchTerm}
                  classes={{
                    root: classes.inputRoot,
                    input: classes.inputInput
                  }}
                  onChange={this.handleSearchInputChange}
                />
                <IconButton
                  centerRipple={true}
                  color="inherit"
                  component={ToSearchScreen}
                  onClick={this.handleSearchOnClick}
                >
                  <SearchIcon />
                </IconButton>
              </div>
            )}

            <span className={classes.grow} />

            <Hidden smDown={true}>
              <Button
                centerRipple={true}
                color="inherit"
                component={ToPricingScreen}
              >
                Pricing
              </Button>
              <Button
                centerRipple={true}
                color="inherit"
                component={ToAdministrationScreen}
              >
                Administration
              </Button>
            </Hidden>

            <IconButton
              centerRipple={true}
              color="inherit"
              onClick={this.handleProfileClick}
            >
              <AccountCircle />
            </IconButton>
            <Popper
              anchorEl={profileAnchorEl}
              open={profileMenuOpen}
              disablePortal={true}
              onClick={this.handleProfileMenuClose}
            >
              <ClickAwayListener onClickAway={this.handleProfileMenuClose}>
                <Paper>
                  <MenuList>
                    <MenuItem button={true} component={ToProfileScreen}>
                      <ListItemIcon>
                        <FilterVintage />
                      </ListItemIcon>
                      <ListItemText primary="Profile" />
                    </MenuItem>

                    <MenuItem
                      button={true}
                      component={ToLoginScreen}
                      onClick={this.handleLogout}
                    >
                      <ListItemIcon>
                        <PowerSettingsNew />
                      </ListItemIcon>
                      <ListItemText primary="Logout" />
                    </MenuItem>
                  </MenuList>
                </Paper>
              </ClickAwayListener>
            </Popper>
          </Toolbar>
        )}

        {!loggedIn && (
          <Toolbar variant="regular">
            <IconButton
              centerRipple={true}
              color="inherit"
              component={ToLandingScreen}
            >
              <EuroSymbol />
            </IconButton>

            <span className={classes.grow} />

            <Button
              centerRipple={true}
              color="inherit"
              component={ToLoginScreen}
            >
              Login
            </Button>
          </Toolbar>
        )}
        <Drawer
          variant="temporary"
          anchor="left"
          open={drawerOpen}
          onClose={this.handleDrawerClose}
        >
          <List>
            <ListItem
              button={true}
              className={classes.drawerHeader}
              component={ToLandingScreen}
            >
              <ListItemIcon>
                <EuroSymbol />
              </ListItemIcon>
            </ListItem>

            <Divider />

            <ListItem
              button={true}
              className={classes.drawerItem}
              component={ToPricingScreen}
            >
              <ListItemText primary="Pricing" />
            </ListItem>

            <ListItem
              button={true}
              className={classes.drawerItem}
              component={ToAdministrationScreen}
            >
              <ListItemText primary="Administration" />
            </ListItem>
          </List>
        </Drawer>
      </AppBar>
    );
  }

  private handleMenuClick(e: React.MouseEvent<HTMLButtonElement>) {
    this.setState({
      drawerOpen: true
    });
  }

  private handleDrawerClose(e: React.MouseEvent<HTMLDivElement>) {
    this.setState({
      drawerOpen: false
    });
  }

  private handleSearchInputChange(e: React.ChangeEvent<HTMLInputElement>) {
    const searchTerm = e.currentTarget.value;
    const { updateSearchTerm } = this.props;
    console.log(searchTerm);
    updateSearchTerm(searchTerm);
  }

  private handleSearchOnKeyDown(e: React.KeyboardEvent<HTMLDivElement>) {
    if (e.keyCode === 13) {
      this.setState({
        shouldSearch: true
      });
    }
  }

  private handleSearchOnClick(e: React.MouseEvent<HTMLButtonElement>) {
    this.setState({
      shouldSearch: true
    });
  }

  private handleProfileClick(e: React.MouseEvent<HTMLButtonElement>) {
    const anchorEl = e.currentTarget;

    this.setState({
      profileAnchorEl: anchorEl,
      profileMenuOpen: true
    });
  }

  private handleProfileMenuClose(e: React.SyntheticEvent) {
    this.setState({
      profileAnchorEl: null,
      profileMenuOpen: false
    });
  }

  private handleLogout() {
    const { updateLoginStatus } = this.props;

    this.setState({
      profileAnchorEl: null
    });

    updateLoginStatus(false);
  }
}

// Styles
const styles = (theme: Theme) =>
  createStyles({
    appBar: {
      flexGrow: 1
    },
    grow: {
      flexGrow: 1
    },
    search: {
      display: "flex",
      flexDirection: "row",
      justifyContent: "center",
      alignItems: "center",
      backgroundColor: fade(theme.palette.common.white, 0.15),
      "&:hover": {
        backgroundColor: fade(theme.palette.common.white, 0.25)
      },
      borderRadius: theme.shape.borderRadius,
      width: "100%",
      marginLeft: theme.spacing.unit,
      marginRight: theme.spacing.unit,
      [theme.breakpoints.up("sm")]: {
        width: "auto"
      }
    },
    inputRoot: {
      color: "inherit",
      width: "100%"
    },
    inputInput: {
      height: "100%",
      width: "100%",
      [theme.breakpoints.up("sm")]: {
        width: 220,
        "&:focus": {
          width: 310
        }
      },
      transition: theme.transitions.create("width"),
      padding: theme.spacing.unit,
      paddingLeft: theme.spacing.unit * 3
    },
    drawerHeader: {
      justifyContent: "center"
    },
    drawerItem: {
      paddingLeft: theme.spacing.unit * 3,
      paddingRight: theme.spacing.unit * 10
    }
  });

export default withStyles(styles)(MenuBarComponent);
