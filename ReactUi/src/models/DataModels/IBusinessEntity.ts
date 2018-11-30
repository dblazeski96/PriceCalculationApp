import { IBaseModel } from "./IBaseModel";

export interface IBusinessEntity extends IBaseModel {
  Name: string;
  Type: string;
  Currency: string;
}
