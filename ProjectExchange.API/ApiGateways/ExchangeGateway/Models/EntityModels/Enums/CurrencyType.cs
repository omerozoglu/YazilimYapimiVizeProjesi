namespace ExchangeGateway.Models.EntityModels.Enums {
    public class CurrencyType {
        public CurrencyType (string value) { Value = value; }
        public string Value { get; set; }
        public static CurrencyType TurkishLira { get { return new CurrencyType (nameof (TurkishLira)); } }
        public static CurrencyType Euro { get { return new CurrencyType (nameof (Euro)); } }
        public static CurrencyType Sterling { get { return new CurrencyType (nameof (Sterling)); } }
        public static CurrencyType SwissFrank { get { return new CurrencyType (nameof (SwissFrank)); } }
    }
}