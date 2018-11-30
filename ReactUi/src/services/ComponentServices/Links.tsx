import * as React from "react";
import { Link } from "react-router-dom";

export const ToLandingScreen = (props: any) => <Link to="/" {...props} />;

export const ToSearchScreen = (props: any) => <Link to="/search" {...props} />;

export const ToPricingScreen = (props: any) => (
  <Link to="/pricing" {...props} />
);

export const ToAdministrationScreen = (props: any) => (
  <Link to="/administration" {...props} />
);

export const ToLoginScreen = (props: any) => <Link to="/login" {...props} />;

export const ToProfileScreen = (props: any) => (
  <Link to="/profile" {...props} />
);
