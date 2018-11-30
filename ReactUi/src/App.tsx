import * as React from "react";
import { Switch, Route } from "react-router-dom";

import CssBaseline from "@material-ui/core/CssBaseline";

import store from "./redux/reduxStore/store";

import { RedirectToLoginScreen } from "./services/ComponentServices/Redirects";
import LandingScreen from "./screens/LandingScreen";
import SearchScreen from "./screens/SearchScreen";
import PricingScreen from "./screens/PricingScreen";
import AdministrationScreen from "./screens/AdministrationScreen";
import LoginScreen from "./screens/LoginScreen";
import ProfileScreen from "./screens/ProfileScreen";
import NotFoundScreen from "./screens/NotFoundScreen";

class App extends React.Component {
  constructor(props: any) {
    super(props);
  }

  public render() {
    const loggedIn = store.getState().commonState.loggedIn;

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
          <Route path="/login" component={LoginScreen} />
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
