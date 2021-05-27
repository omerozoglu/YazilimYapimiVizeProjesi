using Domain.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common {
    public class ApprovalEntityBase {
        [BsonElement ("UserId")]
        public string UserId { get; set; }
        public ApprovalType Type { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}