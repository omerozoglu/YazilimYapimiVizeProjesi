using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common {
    public class EntityBase {

        //* EntityBase servisde oluacak olası tüm entitylerin sahip olması gereken özellikleri taşır.
        //* Bson anontions MongoDb için gerekli olduğundan kullanıldı daha fazla bilgi için https://www.mongodb.com/json-and-bson#what-is-bson-
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}