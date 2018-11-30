import Axios, { AxiosPromise } from "axios";
import apihost from "./apihost";

import { IBusinessItem } from "src/models/DataModels/IBusinessItem";

export const getAllBusinessItems = (): AxiosPromise<IBusinessItem[]> =>
  Axios.get(
    `http://${apihost}/api/search/GetAllBusinessItems?property=%20&searchCriteria=`
  );

export const searchBusinessItems = (
  prop: string,
  searchCriteria: string
): AxiosPromise<IBusinessItem[]> =>
  Axios.get(
    `http://${apihost}/api/search/GetAllBusinessItems?property=${prop}&searchCriteria=${searchCriteria}`
  );

export const changeBusinessItem = (item: IBusinessItem): AxiosPromise =>
  Axios.post(`http://${apihost}/api/search/ChangeBusinessItem`, item);

export const changeMultipleBusinessItems = (
  prop: string,
  value: string,
  items: number[]
): AxiosPromise =>
  Axios.post(
    `http://${apihost}/api/search/ChangePropertyOfMultipleBusinessItems?property=${prop}&value=${value}`,
    items
  );
