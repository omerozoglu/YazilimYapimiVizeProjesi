using Domain.Common.Enums;

namespace Domain.Common {
    public class ApprovalEntityBase : EntityBase {
        public string UserId { get; set; }
        public ApprovalType Type { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}