import * as React from "react";

import Grid from "@material-ui/core/Grid";
import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";

import Error from "@material-ui/icons/Error";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

// IProps
interface IProps extends WithStyles<typeof styles> {}

// Styles
const styles = (theme: Theme) =>
  createStyles({
    root: {
      marginTop: theme.spacing.unit * 2,
      paddingTop: theme.spacing.unit * 10,
      paddingBottom: theme.spacing.unit * 10
    },
    errorMsg: {
      marginTop: theme.spacing.unit * 5
    }
  });

// Component
const NotFoundScreen = ({ classes }: IProps) => (
  <Grid container={true} justify="center" alignItems="center">
    <Grid item={true} xs={11}>
      <Paper className={classes.root}>
        <Typography align="center" color="error">
          <Error fontSize="large" />
        </Typography>
        <Typography align="center" variant="overline" color="error">
          Error 404:
        </Typography>
        <Typography align="center" variant="headline" color="textSecondary">
          Page Not Found.
        </Typography>
        <Typography
          className={classes.errorMsg}
          align="center"
          variant="display1"
          color="error"
        >
          Please check your URL! <br /> "{window.location.origin}
          {window.location.pathname}" does not exist!
        </Typography>
        <IconButton />
      </Paper>
    </Grid>
  </Grid>
);

export default withStyles(styles)(NotFoundScreen);
