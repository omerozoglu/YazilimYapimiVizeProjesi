export class AccountType {
  private constructor(value: string) { this.value = value; }
  value: string;
  public static Taker: AccountType = new AccountType("Taker");
  public static Selller: AccountType = new AccountType("Seller");
  public static Admin: AccountType = new AccountType("Admin");
}
