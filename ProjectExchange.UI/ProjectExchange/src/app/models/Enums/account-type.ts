export class AccountType {
  private constructor(value: string) { this.Value = value; }
  Value: string;
  public static Taker: AccountType = new AccountType("Taker");
  public static Selller: AccountType = new AccountType("Seller");
  public static Admin: AccountType = new AccountType("Admin");
}
