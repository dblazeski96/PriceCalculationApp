import * as React from "react";

import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

import { MenuBar } from "../containers/MenuBar";

export const ProfileScreen = (props: any) => (
  <div>
    <MenuBar />

    <Paper>
      <Typography>Profile Screen Placeholder</Typography>
    </Paper>
  </div>
);
