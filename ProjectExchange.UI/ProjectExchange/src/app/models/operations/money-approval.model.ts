import { ApprovalStatus } from "../Enums/approval-status.enum"
import { ApprovalType } from "../Enums/approval-type.enum"
import { CurrencyType } from "../Enums/currency-type";

export class MoneyApproval {
  id: string;
  userId: string;
  type: ApprovalType;
  status: ApprovalStatus;
  deposit: number;
  currency: CurrencyType;
}
