namespace ExchangeGateway.Models.EntityModels.Enums {
    public class OperationType {

        //* Enum kullanımı gibi string kullanımı bknz:https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top
        public OperationType (string value) { Value = value; }
        public string Value { get; set; }
        public static OperationType Take { get { return new OperationType (nameof (Take)); } }
        public static OperationType Sell { get { return new OperationType (nameof (Sell)); } }
        public static OperationType Load { get { return new OperationType (nameof (Load)); } }
        public static OperationType Deposit { get { return new OperationType (nameof (Deposit)); } }
    }
}