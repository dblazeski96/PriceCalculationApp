import * as React from "react";
import { Switch, Route } from "react-router-dom";

import CssBaseline from "@material-ui/core/CssBaseline";

import reduxStore from "./redux/store/reduxStore";

import {
  RedirectToLoginScreen,
  RedirectToSearchScreen
} from "./services/componentServices/Redirects";

import LandingScreen from "./containers/screenContainers/LandingScreenContainer";
import SearchScreen from "./containers/screenContainers/SearchScreenContainer";
import PricingScreen from "./containers/screenContainers/PricingScreenContainer";
import AdministrationScreen from "./containers/screenContainers/AdministrationScreenContainer";
import LoginScreen from "./containers/screenContainers/LoginScreenContainer";
import ProfileScreen from "./containers/screenContainers/ProfileScreenContainer";
import NotFoundScreen from "./containers/screenContainers/NotFoundScreenContainer";

class App extends React.Component {
  constructor(props: any) {
    super(props);
  }

  public render() {
    const loggedIn = reduxStore.getState().mainState.loggedIn;

    return (
      <div>
        <CssBaseline />

        <Switch>
          <Route exact={true} path="/" component={LandingScreen} />
          <Route
            path="/search"
            component={loggedIn ? SearchScreen : RedirectToLoginScreen}
          />
          <Route
            path="/pricing"
            component={loggedIn ? PricingScreen : RedirectToLoginScreen}
          />
          <Route
            path="/administration"
            component={loggedIn ? AdministrationScreen : RedirectToLoginScreen}
          />
          <Route
            path="/login"
            component={loggedIn ? RedirectToSearchScreen : LoginScreen}
          />
          <Route
            path="/profile"
            component={loggedIn ? ProfileScreen : RedirectToLoginScreen}
          />
          <Route path="/" component={NotFoundScreen} />
        </Switch>
      </div>
    );
  }
}

export default App;
