import Axios, { AxiosPromise } from "axios";
import { IBusinessItem } from "src/models/IBusinessItem";
import { IBaseModel } from "src/models/BaseModel/IBaseModel";

export let getAllBusinessItems = (): AxiosPromise<IBusinessItem[]> =>
  Axios.get(
    "http://localhost:2888/api/search/GetAllBusinessItems?property=%20&searchCriteria="
  );

export let searchBusinessItems = (
  prop: string,
  searchCriteria: string
): AxiosPromise<IBusinessItem[]> =>
  Axios.get(
    `http://localhost:2888/api/search/GetAllBusinessItems?property=${prop}&searchCriteria=${searchCriteria}`
  );

export let changeMultipleBusinessItems = (
  prop: string,
  value: string,
  items: number[]
): AxiosPromise<any> =>
  Axios.post(
    `http://localhost:2888/api/search/ChangePropertyOfMultipleBusinessItems?property=${prop}&value=${value}`,
    items
  );

export let changeBusinessItem = (item: IBaseModel): AxiosPromise<any> =>
  Axios.post(`http://localhost:2888/api/search/ChangeBusinessItem`, item);
