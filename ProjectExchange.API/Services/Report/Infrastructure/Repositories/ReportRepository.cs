using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class ReportRepository : MongoDBRepositoryBase<Report>, IReportRepository {

        //* İhtiyaca yönelik Report repository
        public ReportRepository (ReportMongoContext context) : base (context) { }
    }
}