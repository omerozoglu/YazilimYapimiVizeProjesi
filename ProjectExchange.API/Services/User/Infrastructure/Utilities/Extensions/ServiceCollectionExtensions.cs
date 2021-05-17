using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure.Utilites.Extensions.StartupExtensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddMongoDbSettings (this IServiceCollection services,
            IConfiguration configuration) {
            return services.Configure<MongoDbSettings> (options => {
                options.ConnectionString = configuration
                    .GetSection (nameof (MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
                options.DatabaseName = configuration
                    .GetSection (nameof (MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
                options.CollectionName = configuration
                    .GetSection (nameof (MongoDbSettings) + ":" + MongoDbSettings.CollectionValue).Value;
            });
        }
    }
}