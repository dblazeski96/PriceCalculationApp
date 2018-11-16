import * as React from "react";
import { Switch, Route } from "react-router-dom";

import CssBaseline from "@material-ui/core/CssBaseline";

import { MenuBar } from "./containers/MenuBar";
import { LandingScreen } from "./screens/LandingScreen";
import { SearchScreen } from "./screens/SearchScreen";
import { PricingScreen } from "./screens/PricingScreen";
import { AdministrationScreen } from "./screens/AdministrationScreen";
import LoginScreen from "./screens/LoginScreen";
import { ProfileScreen } from "./screens/ProfileScreen";

class App extends React.Component {
  public render() {
    return (
      <div>
        <CssBaseline />

        <MenuBar />

        <Switch>
          <Route exact={true} path="/" component={LandingScreen} />
          <Route path="/search" component={SearchScreen} />
          <Route path="/pricing" component={PricingScreen} />
          <Route path="/administration" component={AdministrationScreen} />
          <Route path="/login" component={LoginScreen} />
          <Route path="/profile" component={ProfileScreen} />
        </Switch>
      </div>
    );
  }
}

export default App;
