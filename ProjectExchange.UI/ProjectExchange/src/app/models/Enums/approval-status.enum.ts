export class ApprovalStatus {
  private constructor(value: string) { this.Value = value; }
  Value: string;
  public static Approved: ApprovalStatus = new ApprovalStatus("Approved");
  public static Pending: ApprovalStatus = new ApprovalStatus("Pending");
  public static Denied: ApprovalStatus = new ApprovalStatus("Denied");
}
