export class ApprovalType {
  private constructor(value: string) { this.value = value; }
  value: string;
  public static Load: ApprovalType = new ApprovalType("Load");
  public static Deposit: ApprovalType = new ApprovalType("Deposit");
}
