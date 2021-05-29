using Newtonsoft.Json;

namespace ExchangeGateway.Models.EntityModels.Enums {
    public class ApprovalStatus {
        //* Enum kullanımı gibi string kullanımı bknz:https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top
        [JsonConstructor]
        public ApprovalStatus (string value) { Value = value; }
        public string Value { get; set; }
        public static ApprovalStatus Approved { get { return new ApprovalStatus (nameof (Approved)); } }
        public static ApprovalStatus Pending { get { return new ApprovalStatus (nameof (Pending)); } }
        public static ApprovalStatus Denied { get { return new ApprovalStatus (nameof (Denied)); } }
    }
}