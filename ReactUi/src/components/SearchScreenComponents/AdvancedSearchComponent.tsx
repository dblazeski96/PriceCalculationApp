import * as React from "react";

import Paper from "@material-ui/core/Paper";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import TextField from "@material-ui/core/TextField";
import OutlinedInput from "@material-ui/core/OutlinedInput";
import IconButton from "@material-ui/core/IconButton";

import SearchIcon from "@material-ui/icons/Search";

import {
  createStyles,
  withStyles,
  Theme,
  WithStyles
} from "@material-ui/core/styles";

import { casingToRender } from "src/services/valueService";

// IProps
interface IProps extends WithStyles<typeof styles> {
  itemProps: string[] | null;
  selectedSearchProp: string;
  searchTerm: string;
  shouldFetch: boolean;
  isFetching: boolean;

  updateSelectedSearchProp: (selectedSearchProp: string) => void;
  updateSearchTerm: (searchTerm: string) => void;
  updateShouldFetch: (shouldFetch: boolean) => void;
}

// Component
class AdvancedSearchComponent extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);

    this.handleSelectSearchProp = this.handleSelectSearchProp.bind(this);
    this.handleChangeSearchTerm = this.handleChangeSearchTerm.bind(this);
    this.handleSearch = this.handleSearch.bind(this);
  }

  // Render
  public render() {
    const { classes, itemProps, selectedSearchProp, searchTerm } = this.props;

    return (
      <Paper className={classes.root}>
        <FormControl className={classes.container}>
          <Select
            value={selectedSearchProp}
            input={<OutlinedInput labelWidth={0} />}
            className={[classes.containerItem, classes.selectComponent].join(
              " "
            )}
            onChange={this.handleSelectSearchProp}
          >
            {itemProps &&
              itemProps.map(p => (
                <MenuItem button={true} value={p} key={p}>
                  {casingToRender(p) as string}
                </MenuItem>
              ))}
          </Select>

          <TextField
            variant="outlined"
            placeholder="Search something..."
            value={searchTerm}
            className={[classes.containerItem, classes.textField].join(" ")}
            onChange={this.handleChangeSearchTerm}
          />

          <IconButton
            color="primary"
            className={[classes.containerItem, classes.searchBtn].join(" ")}
            onClick={this.handleSearch}
          >
            <SearchIcon fontSize="small" />
          </IconButton>
        </FormControl>
      </Paper>
    );
  }

  private handleSelectSearchProp(e: React.ChangeEvent<HTMLSelectElement>) {
    const selectedItem = e.target.value;
    const { updateSelectedSearchProp } = this.props;

    updateSelectedSearchProp(selectedItem);
  }

  private handleChangeSearchTerm(e: React.ChangeEvent<HTMLInputElement>) {
    const searchTerm = e.currentTarget.value;
    const { updateSearchTerm } = this.props;

    updateSearchTerm(searchTerm);
  }

  private handleSearch(e: React.MouseEvent<HTMLButtonElement>) {
    const { shouldFetch, isFetching, updateShouldFetch } = this.props;

    if (!shouldFetch && !isFetching) {
      updateShouldFetch(true);
    } else {
      updateShouldFetch(false);
    }
  }
}

// Styles
const styles = (theme: Theme) =>
  createStyles({
    root: {
      display: "flex",
      justifyContent: "center",
      alignItems: "center",
      margin: theme.spacing.unit * 0.4
    },
    container: {
      flexDirection: "row",
      margin: theme.spacing.unit * 2
    },
    containerItem: {
      margin: theme.spacing.unit * 0.2,
      maxHeight: theme.spacing.unit * 5
    },
    selectComponent: {
      minWidth: theme.spacing.unit * 20
    },
    textField: {
      width: theme.spacing.unit * 70
    },
    searchBtn: {
      maxWidth: theme.spacing.unit * 5,
      marginLeft: -(theme.spacing.unit * 5)
    }
  });

export default withStyles(styles)(AdvancedSearchComponent);
