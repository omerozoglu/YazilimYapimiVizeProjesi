using Application.Contracts.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Utilites.Extensions.StartupExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure {
    public static class InfrastructureServiceRegistration {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) {
            services.AddMongoDbSettings (configuration);
            services.AddScoped<MongoDbCommonEntityContext> ();
            services.AddScoped<ICommonEntityRepository, CommonEntityRepository> ();
            services.AddScoped (typeof (IAsyncRepository<>), typeof (MongoDbRepositoryBase<>));
            return services;
        }
    }
}