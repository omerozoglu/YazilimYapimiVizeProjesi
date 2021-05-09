using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities {
    public class CommonEntity : EntityBase {

        [BsonElement ("UserId")]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public double Credit { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
    }
}