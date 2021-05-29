using ExchangeGateway.Models.EntityModels.Enums;

namespace ExchangeGateway.Models.EntityModels {
    public class ApprovalEntityBase {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ApprovalType Type { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}