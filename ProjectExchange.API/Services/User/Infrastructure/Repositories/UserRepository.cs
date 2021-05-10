using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class UserRepository : MongoDbRepositoryBase<User>, IUserRepository {

        //* İhtiyaca yönelik User repository
        public UserRepository (MongoDbUserContext context) : base (context) { }

    }
}