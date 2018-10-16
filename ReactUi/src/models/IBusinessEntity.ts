import { IBaseModel } from "./BaseModel/IBaseModel";

export interface IBusinessEntity extends IBaseModel {
  Name: string;
  Type: string;
  Currency: string;
}
