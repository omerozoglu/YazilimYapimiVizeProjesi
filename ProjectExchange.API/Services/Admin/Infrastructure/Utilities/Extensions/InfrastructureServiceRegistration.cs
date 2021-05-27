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
            services.AddScoped<CommonEntityMongoContext<MoneyApproval>> ();
            services.AddScoped<CommonEntityMongoContext<ProductApproval>> ();
            services.AddScoped<ICommonEntityRepository<MoneyApproval>, CommonEntityRepository<MoneyApproval>> ();
            services.AddScoped<ICommonEntityRepository<ProductApproval>, CommonEntityRepository<ProductApproval>> ();
            services.AddScoped (typeof (IAsyncRepository<>), typeof (MongoDBRepositoryBase<>));
            return services;
        }
    }
}