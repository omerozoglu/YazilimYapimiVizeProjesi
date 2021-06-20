export class OperationType {
  private constructor(value: string) { this.value = value; }
  value: string;
  public static Take: OperationType = new OperationType("Take");
  public static Sell: OperationType = new OperationType("Sell");
  public static Load: OperationType = new OperationType("Load");
  public static Deposit: OperationType = new OperationType("Deposit");
}
