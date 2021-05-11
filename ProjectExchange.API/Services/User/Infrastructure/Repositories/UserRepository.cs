using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class UserRepository : MongoDbRepositoryBase<User>, IUserRepository {

        //* İhtiyaca yönelik User repository
        public UserRepository (MongoDbUserContext context) : base (context) { }

        public async Task<bool> UpdateOnePropertyUser (string id, string property, object value) {
            var update = Builders<User>.Update.Set (property, value);
            var options = new UpdateOptions { };
            var filter = Builders<User>.Filter.Eq (x => x.Id, id);
            //  _context.Collection.UpdateOneAsync ();
            await _context.Collection.UpdateOneAsync (filter, update, options);
            return true;
        }
    }
}