import axios, { AxiosPromise } from "axios";
import { IBusinessEntity } from "src/models/IBusinessEntity";

export let getAllBusinessEntities = (): AxiosPromise<IBusinessEntity[]> => {
  return axios.get(
    "http://localhost:2888/api/search/GetAllBusinessEntities?property=%20&searchCriteria="
  );
};
