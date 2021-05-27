using Application.Contracts.Persistence;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class CommonEntityRepository<T> : MongoDBRepositoryBase<CommonEntity<T>>, ICommonEntityRepository<T> where T : ApprovalEntityBase {

        //* İhtiyaca yönelik Product repository
        public CommonEntityRepository (CommonEntityMongoContext<T> context) : base (context) {

        }
    }
}