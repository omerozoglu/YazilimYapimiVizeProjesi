export class CurrencyType {
  private constructor(value: string) { this.value = value; }
  value: string;
  public static TRY: CurrencyType = new CurrencyType("TRY");
  public static GBP: CurrencyType = new CurrencyType("GBP");
  public static EUR: CurrencyType = new CurrencyType("EUR");
  public static CHF: CurrencyType = new CurrencyType("CHF");
}
