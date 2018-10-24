import Axios, { AxiosPromise } from "axios";
import { IBusinessItem } from "src/models/IBusinessItem";

export let getAllBusinessItems = (): AxiosPromise<IBusinessItem[]> => {
  return Axios.get(
    "http://localhost:2888/api/search/GetAllBusinessItems?property=%20&searchCriteria="
  );
};

export let changePropertyOfMultipleBusinessItems = (
  prop: string,
  value: string,
  items: number[]
): AxiosPromise<any> => {
  alert(items);
  return Axios.post(
    `http://localhost:2888/api/search/ChangePropertyOfMultipleBusinessItems?property=${prop}&value=${value}`,
    items
  );
};

export let searchBusinessItems = (
  prop: string,
  searchCriteria: string
): AxiosPromise<IBusinessItem[]> => {
  return Axios.get(
    `http://localhost:2888/api/search/GetAllBusinessItems?property=${prop}&searchCriteria=${searchCriteria}`
  );
};
