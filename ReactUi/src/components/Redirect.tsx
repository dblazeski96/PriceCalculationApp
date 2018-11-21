import * as React from "react";
import { Redirect } from "react-router-dom";

export const RedirectToSearchScreen = (props: any) => (
  <Redirect to="/search" {...props} />
);

export const RedirectToLoginScreen = (props: any) => (
  <Redirect to="login" {...props} />
);
