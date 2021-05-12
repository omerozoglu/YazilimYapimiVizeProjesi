using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public interface IMongoContext<T> {
        IMongoCollection<T> Collection { get; }
    }
}