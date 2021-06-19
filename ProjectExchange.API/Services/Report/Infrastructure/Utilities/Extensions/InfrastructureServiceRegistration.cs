using Application.Contracts.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utilites.Extensions {
    public static class InfrastructureServiceRegistration {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) {
            services.AddMongoDbSettings (configuration);
            services.AddScoped<ReportMongoContext> ();
            services.AddScoped<IReportRepository, ReportRepository> ();
            services.AddScoped (typeof (IAsyncRepository<>), typeof (MongoDBRepositoryBase<>));
            return services;
        }
    }
}