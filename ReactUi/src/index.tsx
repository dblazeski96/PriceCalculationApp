import * as React from "react";
import * as ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import registerServiceWorker from "./registerServiceWorker";

import "roboto-fontface";
import "./index.css";

import { createMuiTheme, MuiThemeProvider } from "@material-ui/core/styles";

import reduxStore from "./redux/store/reduxStore";
import App from "./App";

const theme = createMuiTheme({
  palette: {
    primary: {
      main: "#1976d2"
    },
    secondary: {
      main: "#0d47a1"
    }
  }
});

ReactDOM.render(
  <BrowserRouter>
    <Provider store={reduxStore}>
      <MuiThemeProvider theme={theme}>
        <App />
      </MuiThemeProvider>
    </Provider>
  </BrowserRouter>,
  document.getElementById("root") as HTMLElement
);

registerServiceWorker();
