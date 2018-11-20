import * as React from "react";

import { MenuBar } from "../containers/MenuBar";
import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

export const LandingScreen = (props: any) => (
  <div>
    <MenuBar />

    <Paper>
      <Typography>Landing Screen Placeholder</Typography>
    </Paper>
  </div>
);
