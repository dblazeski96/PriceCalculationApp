import Axios, { AxiosPromise } from "axios";
import { IBusinessEntity } from "src/models/IBusinessEntity";

export let getAllBusinessEntities = (): AxiosPromise<IBusinessEntity[]> =>
  Axios.get(
    "http://localhost:2888/api/search/GetAllBusinessEntities?property=%20&searchCriteria="
  );

export let searchBusinessEntities = (
  prop: string,
  searchCriteria: string
): AxiosPromise<IBusinessEntity[]> =>
  Axios.get(
    `http://localhost:2888/api/search/GetAllBusinessEntities?property=${prop}&searchCriteria=${searchCriteria}`
  );

export let changeMultipleBusinessEntities = (
  prop: string,
  value: string,
  items: number[]
): AxiosPromise<any> =>
  Axios.post(
    `http://localhost:2888/api/search/ChangePropertyOfMultipleBusinessEntities?property=${prop}&value=${value}`,
    items
  );
