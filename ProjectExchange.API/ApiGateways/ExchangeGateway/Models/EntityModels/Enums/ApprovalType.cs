using Newtonsoft.Json;

namespace ExchangeGateway.Models.EntityModels.Enums {
    public class ApprovalType {
        //* Enum kullanımı gibi string kullanımı bknz:https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top
        [JsonConstructor]
        public ApprovalType (string value) { Value = value; }
        public string Value { get; set; }
        public static ApprovalType Load { get { return new ApprovalType (nameof (Load)); } }
        public static ApprovalType Deposit { get { return new ApprovalType (nameof (Deposit)); } }
    }
}