using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application {
    public static class ApplicationServiceRegistration {
        public static IServiceCollection AddApplicationservices (this IServiceCollection services) {

            services.AddAutoMapper (Assembly.GetExecutingAssembly ());
            services.AddMediatR (Assembly.GetExecutingAssembly ());
            return services;
        }
    }
}