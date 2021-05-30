export class ApprovalType {
  private constructor(value: string) { this.Value = value; }
  Value: string;
  public static Load: ApprovalType = new ApprovalType("Load");
  public static Deposit: ApprovalType = new ApprovalType("Deposit");
}
