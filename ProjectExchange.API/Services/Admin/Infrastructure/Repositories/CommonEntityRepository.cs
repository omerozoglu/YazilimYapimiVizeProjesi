using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class CommonEntityRepository : MongoDBRepositoryBase<CommonEntity>, ICommonEntityRepository {

        //* İhtiyaca yönelik Product repository
        public CommonEntityRepository (CommonEntityMongoContext context) : base (context) {

        }
    }
}