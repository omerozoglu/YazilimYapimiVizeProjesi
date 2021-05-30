import { ApprovalStatus } from "../Enums/approval-status.enum"
import { ApprovalType } from "../Enums/approval-type.enum"

export class ProductApproval {
  id: string;
  userId: string;
  type: ApprovalType;
  status: ApprovalStatus;
  productName: string;
  productImgUrl: string;
  productWeight: number;
}
