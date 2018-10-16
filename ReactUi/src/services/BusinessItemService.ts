import axios, { AxiosPromise } from "axios";
import { IBusinessItem } from "src/models/IBusinessItem";

export let getAllBusinessItems = (): AxiosPromise<IBusinessItem[]> => {
  return axios.get(
    "http://localhost:2888/api/search/GetAllBusinessItems?property=%20&searchCriteria="
  );
};
