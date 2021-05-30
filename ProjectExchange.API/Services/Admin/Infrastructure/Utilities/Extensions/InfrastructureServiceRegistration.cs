using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utilites.Extensions {
    public static class InfrastructureServiceRegistration {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) {
            services.AddMongoDbSettings (configuration);
            services.AddScoped<ApprovalEntityBaseMongoContext<MoneyApproval>> ();
            services.AddScoped<ApprovalEntityBaseMongoContext<ProductApproval>> ();
            services.AddScoped<IApprovalEntityRepository<MoneyApproval>, ApprovalEntityRepository<MoneyApproval>> ();
            services.AddScoped<IApprovalEntityRepository<ProductApproval>, ApprovalEntityRepository<ProductApproval>> ();
            services.AddScoped (typeof (IAsyncRepository<>), typeof (MongoDBRepositoryBase<>));
            return services;
        }
    }
}