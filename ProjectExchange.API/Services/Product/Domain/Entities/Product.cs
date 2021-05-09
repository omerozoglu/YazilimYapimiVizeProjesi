using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities {
    public class Product : EntityBase {
        [BsonElement ("Name")]
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int Weight { get; set; }
        public int UnitPrice { get; set; }
    }
}