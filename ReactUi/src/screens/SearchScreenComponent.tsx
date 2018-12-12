import * as React from "react";

import Grid from "@material-ui/core/Grid";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import { Item } from "src/models/DataModels/Item";
import { IBaseModel } from "src/models/DataModels/IBaseModel";

import { fetchDataGetItems } from "src/services/apiServices/fetchDataService";

import MenuBar from "src/containers/MenuBarContainer";
import AdvancedSearch from "src/components/SearchScreenComponents/AdvancedSearchComponent";
import ItemTable from "src/components/SearchScreenComponents/ItemTableComponent";

// IProps
interface IProps extends WithStyles<typeof styles> {
  selectedItem: Item;
  selectedSearchProp: string;
  searchTerm: string;

  updateIsOnSearchScreen: (isOnSearchScreen: boolean) => void;

  updateSelectedItem: (selectedItem: Item) => void;
  updateSelectedSearchProp: (selectedSearchProp: string) => void;
  updateSearchTerm: (searchTerm: string) => void;
}

// IState
interface IState {
  ItemData: IBaseModel[] | null;
  itemProps: string[] | null;
  shouldFetch: boolean;
  isFetching: boolean;
}

// Component
class SearchScreenComponent extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);

    this.state = {
      ItemData: null,
      itemProps: null,
      shouldFetch: false,
      isFetching: false
    };

    this.updateShouldFetch = this.updateShouldFetch.bind(this);
    this.fetchData = this.fetchData.bind(this);
  }
  // Mount
  public componentDidMount() {
    const { updateIsOnSearchScreen } = this.props;

    updateIsOnSearchScreen(true);

    this.fetchData();
  }

  // Unmount
  public componentWillUnmount() {
    const { updateIsOnSearchScreen } = this.props;

    updateIsOnSearchScreen(false);
  }

  // Update
  public componentDidUpdate() {
    const { shouldFetch } = this.state;

    if (shouldFetch) {
      this.setState({
        shouldFetch: false,
        isFetching: true
      });

      this.fetchData();
    }
  }

  // Render
  public render() {
    const {
      selectedItem,
      selectedSearchProp,
      searchTerm,
      updateSelectedItem,
      updateSelectedSearchProp,
      updateSearchTerm
    } = this.props;
    const { shouldFetch, isFetching, ItemData, itemProps } = this.state;

    return (
      <Grid container={true} justify="center" alignItems="center">
        <Grid item={true} xs={12}>
          <MenuBar />
        </Grid>

        <Grid item={true} xs={11}>
          <AdvancedSearch
            itemProps={itemProps}
            selectedSearchProp={selectedSearchProp}
            searchTerm={searchTerm}
            shouldFetch={shouldFetch}
            isFetching={isFetching}
            updateSelectedSearchProp={updateSelectedSearchProp}
            updateSearchTerm={updateSearchTerm}
            updateShouldFetch={this.updateShouldFetch}
          />
        </Grid>

        <Grid item={true} xs={11}>
          <ItemTable
            selectedItem={selectedItem}
            itemData={ItemData}
            itemProps={itemProps}
            shouldFetch={shouldFetch}
            isFetching={isFetching}
            updateSelectedItem={updateSelectedItem}
            updateSelectedSearchProp={updateSelectedSearchProp}
            updateSearchTerm={updateSearchTerm}
            updateShouldFetch={this.updateShouldFetch}
          />
        </Grid>
      </Grid>
    );
  }

  private updateShouldFetch(shouldFetch: boolean) {
    this.setState({
      shouldFetch
    });
  }

  private fetchData() {
    const { selectedItem, selectedSearchProp, searchTerm } = this.props;

    fetchDataGetItems(selectedItem, selectedSearchProp, searchTerm)
      .then(res => {
        this.setState({
          ItemData: res.data,
          itemProps: Object.keys(res.data[0]),
          isFetching: false
        });
      })
      .catch(e => {
        this.setState({
          isFetching: false
        });
      });
  }
}

// Styles
const styles = (theme: Theme) => createStyles({});

export default withStyles(styles)(SearchScreenComponent);
