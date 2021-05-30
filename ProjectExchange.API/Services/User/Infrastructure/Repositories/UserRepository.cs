using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class UserRepository : MongoDBRepositoryBase<User>, IUserRepository {

        //* İhtiyaca yönelik User repository
        public UserRepository (UserMongoContext context) : base (context) { }
    }
}