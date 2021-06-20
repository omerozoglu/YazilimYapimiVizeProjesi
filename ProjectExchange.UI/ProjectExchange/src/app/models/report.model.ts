import { OperationType } from "./Enums/operation-type";

export class Report {
  id: string;
  operationType: OperationType;
  createdBy: string;
  createdDate: string;
  productName: string;
  weight: number;
  unitPrice: number;
}
