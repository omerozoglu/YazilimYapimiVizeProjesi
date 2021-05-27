using System.Reflection;
using Application.Behaviours;
using Domain.Common;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Utilities.Extensions {
    public static class ApplicationServiceRegistration {
        public static IServiceCollection AddApplicationservices (this IServiceCollection services) {

            services.AddAutoMapper (Assembly.GetExecutingAssembly ());
            services.AddValidatorsFromAssembly (Assembly.GetExecutingAssembly ());
            services.AddMediatR (Assembly.GetExecutingAssembly ());

            services.AddTransient (typeof (IPipelineBehavior<,>), typeof (ValidationBehaviour<,>));

            return services;
        }
    }
}