import { ApprovalStatus } from "../Enums/approval-status.enum"
import { ApprovalType } from "../Enums/approval-type.enum"

export class MoneyApproval {
  id: string;
  userId: string;
  type: ApprovalType;
  status: ApprovalStatus;
  deposit: number;
}
