using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities {
    public class CommonEntity<T> : EntityBase where T : ApprovalEntityBase {

        public T ApprovalEntity { get; set; }
    }
}