import { IBaseModel } from "./IBaseModel";

export interface IBusinessItem extends IBaseModel {
  Name: string;
  Description: string;
  Group: string;
  Quantity: number;
  PriceCost: number;
  PriceTarget: number;
  PricePremium: number;
  DateOfProduction: Date;
  DateOfLastSoldItem: Date;
}
