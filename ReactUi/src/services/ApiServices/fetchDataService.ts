import { AxiosPromise } from "axios";

import { Item } from "src/models/DataModels/Item";
import { IBaseModel } from "src/models/DataModels/IBaseModel";
import { IBusinessItem } from "src/models/DataModels/IBusinessItem";
import { IBusinessEntity } from "src/models/DataModels/IBusinessEntity";

import {
  getAllBusinessItems,
  searchBusinessItems,
  changeBusinessItem,
  changeMultipleBusinessItems
} from "./businessItemService";

import {
  getAllBusinessEntities,
  searchBusinessEntities,
  changeBusinessEntity,
  changeMultipleBusinessEntities
} from "./businessEntityService";

export const fetchDataGetItems = (
  selectedItem: Item,
  searchProp: string,
  searchTerm: string
): AxiosPromise<IBaseModel[]> => {
  switch (selectedItem) {
    case Item.businessItem: {
      return searchTerm
        ? searchBusinessItems(searchProp, searchTerm)
        : getAllBusinessItems();
    }

    case Item.businessEntity: {
      return searchTerm
        ? searchBusinessEntities(searchProp, searchTerm)
        : getAllBusinessEntities();
    }

    default: {
      return getAllBusinessItems();
    }
  }
};

export const fetchDataChangeItem = (
  selectedItem: Item,
  item: IBaseModel
): AxiosPromise => {
  switch (selectedItem) {
    case Item.businessItem: {
      return changeBusinessItem(item as IBusinessItem);
    }

    case Item.businessEntity: {
      return changeBusinessEntity(item as IBusinessEntity);
    }

    default: {
      return changeBusinessItem(item as IBusinessItem);
    }
  }
};

export const fetchDataChangeMultipleItems = (
  selectedItem: Item,
  prop: string,
  value: string,
  items: number[]
): AxiosPromise => {
  switch (selectedItem) {
    case Item.businessItem: {
      return changeMultipleBusinessItems(prop, value, items);
    }

    case Item.businessEntity: {
      return changeMultipleBusinessEntities(prop, value, items);
    }

    default: {
      return changeMultipleBusinessItems(prop, value, items);
    }
  }
};
