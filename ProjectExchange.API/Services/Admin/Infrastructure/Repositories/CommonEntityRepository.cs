using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class CommonEntityRepository : MongoDbRepositoryBase<CommonEntity>, ICommonEntityRepository {

        //* İhtiyaca yönelik Product repository
        public CommonEntityRepository (MongoDbCommonEntityContext context) : base (context) {

        }
    }
}