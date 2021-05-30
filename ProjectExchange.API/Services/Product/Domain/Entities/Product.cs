using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities {
    public class Product : EntityBase {
        [BsonElement ("Name")]
        public string Name { get; set; }
        public string UserId { get; set; }
        public string ImgUrl { get; set; }
        public double Weight { get; set; }
        public double UnitPrice { get; set; }
    }
}