using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public interface IMongoContext<T> {
        void AddCommand (Func<Task> func);
        Task<int> SaveChangesAsync ();
        IMongoCollection<T> Collection { get; }
    }
}