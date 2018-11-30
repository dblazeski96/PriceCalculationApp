import Axios, { AxiosPromise } from "axios";
import apihost from "./apihost";

export const login = (email: string, password: string): AxiosPromise =>
  Axios.get(
    `http://${apihost}/api/login/requestLogin?email=${email}&password=${password}`
  );
