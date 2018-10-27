import * as React from "react";
import { Component } from "react";

import { Search } from "../containers/TableContainers/Search";
import { SelectItem } from "../containers/TableContainers/SelectItem";
import { Table } from "../containers/TableContainers/Table";
import { KopceZaRiki } from "src/containers/KopceZaRiki";
import { ChangeMultipleItems } from "src/containers/TableContainers/ChangeMultipleItems";

export class SearchScreen extends Component {
  public render() {
    return (
      <div>
        <SelectItem />
        <Search />
        <Table />
        <ChangeMultipleItems />
        <KopceZaRiki />
      </div>
    );
  }
}
