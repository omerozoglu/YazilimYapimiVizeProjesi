export class AccountType {
  private constructor(value: number) { this.value = value; }
  value: number;
  public static Taker: AccountType = new AccountType(1);
  public static Selller: AccountType = new AccountType(2);
  public static Admin: AccountType = new AccountType(0);
}
