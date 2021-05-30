using Application.Contracts.Persistence;
using Domain.Common;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class ApprovalEntityRepository<T> : MongoDBRepositoryBase<T>, IApprovalEntityRepository<T> where T : ApprovalEntityBase {

        //* İhtiyaca yönelik Product repository
        public ApprovalEntityRepository (ApprovalEntityBaseMongoContext<T> context) : base (context) {

        }
    }
}