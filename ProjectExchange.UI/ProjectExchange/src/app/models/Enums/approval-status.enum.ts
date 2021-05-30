export class ApprovalStatus {
  private constructor(value: string) { this.value = value; }
  value: string;
  public static Approved: ApprovalStatus = new ApprovalStatus("Approved");
  public static Pending: ApprovalStatus = new ApprovalStatus("Pending");
  public static Denied: ApprovalStatus = new ApprovalStatus("Denied");
}
