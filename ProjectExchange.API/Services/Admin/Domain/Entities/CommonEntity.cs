using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities {
    public class CommonEntity : EntityBase {

        [BsonElement ("UserId")]
        public string UserId { get; set; }
        public double Deposite { get; set; }
        public string ProductId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}