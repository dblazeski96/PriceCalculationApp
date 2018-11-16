import * as React from "react";
import {
  TextField,
  Button,
  MenuItem,
  Select,
  InputLabel,
  FormControl
} from "@material-ui/core";

const styles = {
  test: {
    height: "100%"
  }
};

export interface IProps {
  searchProps: string[];
  defaultSelectedProp: string;
  selectedItem: string;
  selectedSearchProp: string;
  searchTerm: string;

  updateSearchTerm: (event: React.FormEvent<HTMLInputElement>) => void;
  handleOnChangeProp: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  handleSearch: (
    selectedProp: string,
    selectedSearchProp: string,
    searchTerm: string
  ) => (event: React.MouseEvent<HTMLButtonElement>) => void;
}

export const SearchComponent = ({
  searchProps,
  defaultSelectedProp,
  selectedItem,
  selectedSearchProp,
  searchTerm,
  updateSearchTerm,
  handleOnChangeProp,
  handleSearch
}: IProps) => (
  <form style={{ height: "100%" }}>
    <FormControl style={styles.test}>
      <TextField
        defaultValue=""
        label="Search something"
        onInput={updateSearchTerm}
      />
    </FormControl>

    <FormControl style={styles.test}>
      <InputLabel htmlFor="searchProps">Property</InputLabel>
      <Select
        inputProps={{ name: "searchProps", id: "searchProps" }}
        value={selectedSearchProp}
        onChange={handleOnChangeProp}
      >
        {searchProps.map((prop, index) => (
          <MenuItem value={prop} key={`${prop} - ${index}`}>
            {prop}
          </MenuItem>
        ))}
      </Select>
    </FormControl>

    <FormControl style={styles.test}>
      <Button
        style={styles.test}
        onClick={handleSearch(selectedItem, selectedSearchProp, searchTerm)}
      >
        Search
      </Button>
    </FormControl>
  </form>
);
