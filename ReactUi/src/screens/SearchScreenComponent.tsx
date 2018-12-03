import * as React from "react";

import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import { IBaseModel } from "src/models/DataModels/IBaseModel";
import { searchBusinessItems } from "src/services/apiServices/businessItemService";
import { searchBusinessEntities } from "src/services/apiServices/businessEntityService";

import MenuBar from "src/containers/MenuBarContainer";

// IProps
interface IProps extends WithStyles<typeof styles> {
  selectedItem: string;
  searchTerm: string;

  updateIsOnSearchScreen: (isOnSearchScreen: boolean) => void;
}

// State
interface IState {
  data: IBaseModel[] | null;
}

// Component
class SearchScreenComponent extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = {
      data: null
    };
  }

  // Mount
  public componentDidMount() {
    const { updateIsOnSearchScreen, selectedItem, searchTerm } = this.props;

    updateIsOnSearchScreen(true);

    switch (selectedItem) {
      case "businessItem":
        {
          searchBusinessItems("Quantity", searchTerm)
            .then(res => {
              this.setState({
                data: res.data
              });
            })
            .catch(err => {
              console.log(err.response.data);
            });
        }
        break;

      case "businessEntity":
        {
          searchBusinessEntities("Name", searchTerm)
            .then(res => {
              this.setState({
                data: res.data
              });
            })
            .catch(err => {
              console.log(err.response.data);
            });
        }
        break;

      default: {
        searchBusinessItems("Name", searchTerm)
          .then(res => {
            this.setState({
              data: res.data
            });
          })
          .catch(err => {
            console.log(err.response.data);
          });
      }
    }
  }

  // Unmount
  public componentWillUnmount() {
    const { updateIsOnSearchScreen } = this.props;

    updateIsOnSearchScreen(false);
  }

  public render() {
    const { data } = this.state;

    return (
      <div>
        <MenuBar />

        <Paper>
          <Typography>{JSON.stringify(data)}</Typography>
          {console.log(data)}
        </Paper>
      </div>
    );
  }
}

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(SearchScreenComponent);
