import * as React from "react";
import { Switch, Route } from "react-router-dom";

import CssBaseline from "@material-ui/core/CssBaseline";

import { store } from "./redux/reduxStore/store";
import { RedirectToLoginScreen } from "./components/Redirect";
import { LandingScreen } from "./screens/LandingScreen";
import { SearchScreen } from "./screens/SearchScreen";
import { PricingScreen } from "./screens/PricingScreen";
import { AdministrationScreen } from "./screens/AdministrationScreen";
import LoginScreen from "./screens/LoginScreen";
import { ProfileScreen } from "./screens/ProfileScreen";
import NotFoundScreen from "./screens/NotFoundScreen";

class App extends React.Component {
  public render() {
    const logggedIn = store.getState().commonReducer.loggedIn;
    return (
      <div>
        <CssBaseline />

        <Switch>
          <Route exact={true} path="/" component={LandingScreen} />
          <Route
            path="/search"
            component={logggedIn ? SearchScreen : RedirectToLoginScreen}
          />
          <Route
            path="/pricing"
            component={logggedIn ? PricingScreen : RedirectToLoginScreen}
          />
          <Route
            path="/administration"
            component={logggedIn ? AdministrationScreen : RedirectToLoginScreen}
          />
          <Route path="/login" component={LoginScreen} />
          <Route
            path="/profile"
            component={logggedIn ? ProfileScreen : RedirectToLoginScreen}
          />
          <Route path="/" component={NotFoundScreen} />
        </Switch>
      </div>
    );
  }
}

export default App;
