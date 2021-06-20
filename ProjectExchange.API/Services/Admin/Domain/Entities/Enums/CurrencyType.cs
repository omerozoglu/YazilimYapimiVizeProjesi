using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common.Enums {
    public class CurrencyType {
        //* Enum kullanımı gibi string kullanımı bknz:https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top
        [BsonConstructor]
        public CurrencyType (string value) { Value = value; }
        public string Value { get; set; }
        public static CurrencyType TurkishLira { get { return new CurrencyType (nameof (TurkishLira)); } }
        public static CurrencyType Euro { get { return new CurrencyType (nameof (Euro)); } }
        public static CurrencyType Sterling { get { return new CurrencyType (nameof (Sterling)); } }
        public static CurrencyType SwissFrank { get { return new CurrencyType (nameof (SwissFrank)); } }
    }
}