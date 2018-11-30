import * as React from "react";
import { Dispatch } from "redux";
import { connect } from "react-redux";

import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import { IState } from "../redux/reduxStore/IState";
import { updateIsOnSearchScreen } from "../redux/reduxActions/commonActions/commonActionCreators";

import MenuBar from "../containers/MenuBar";

// IProps
interface IProps extends WithStyles<typeof styles> {
  updateIsOnSearchScreenAsProp: (isOnSearchScreen: boolean) => void;
}

// Component
class SearchScreen extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
  }

  // Mount
  public componentDidMount() {
    const { updateIsOnSearchScreenAsProp } = this.props;

    updateIsOnSearchScreenAsProp(true);
  }

  // Unmount
  public componentWillUnmount() {
    const { updateIsOnSearchScreenAsProp } = this.props;

    updateIsOnSearchScreenAsProp(false);
  }

  public render() {
    return (
      <div>
        <MenuBar />

        <Paper>
          <Typography>SearchScreen place holder</Typography>

          <h1>Test</h1>
          <h1>Test</h1>
          <h1>Test</h1>
          <h1>Test</h1>
          <h2>Test</h2>
          <h2>Test</h2>
          <h2>Test</h2>
          <h2>Test</h2>
          <h2>Test</h2>
          <h2>Test</h2>
          <h2>Test</h2>
          <h3>Test</h3>
          <h3>Test</h3>
          <h3>Test</h3>
          <h3>Test</h3>
          <h3>Test</h3>
          <h3>Test</h3>
          <h3>Test</h3>
          <h3>Test</h3>
        </Paper>
      </div>
    );
  }
}

// Styles
const styles = (theme: Theme) => createStyles({});

// Container
const mapStateToProps = (state: IState) => ({});

const mapDispatchToProps = (dispatch: Dispatch) => ({
  updateIsOnSearchScreenAsProp: (isOnSearchScreen: boolean) => {
    dispatch(updateIsOnSearchScreen(isOnSearchScreen));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withStyles(styles)(SearchScreen));
