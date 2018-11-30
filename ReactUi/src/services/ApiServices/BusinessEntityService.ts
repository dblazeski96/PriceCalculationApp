import Axios, { AxiosPromise } from "axios";
import apihost from "./apihost";

import { IBusinessEntity } from "src/models/DataModels/IBusinessEntity";

export const getAllBusinessEntities = (): AxiosPromise<IBusinessEntity[]> =>
  Axios.get(
    `http://${apihost}/api/search/GetAllBusinessEntities?property=%20&searchCriteria=`
  );

export const searchBusinessEntities = (
  prop: string,
  searchCriteria: string
): AxiosPromise<IBusinessEntity[]> =>
  Axios.get(
    `http://${apihost}/api/search/GetAllBusinessEntities?property=${prop}&searchCriteria=${searchCriteria}`
  );

export const changeMultipleBusinessEntities = (
  prop: string,
  value: string,
  items: number[]
): AxiosPromise =>
  Axios.post(
    `http://${apihost}/api/search/ChangePropertyOfMultipleBusinessEntities?property=${prop}&value=${value}`,
    items
  );

export const changeBusinessEntity = (item: IBusinessEntity): AxiosPromise =>
  Axios.post(`http://${apihost}/api/search/ChangeBusinessEntity`, item);
