using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NexusERP.Application.Common.Behaviors;
using NexusERP.Application.Features.Products.commands.createProduct;

namespace NexusERP.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly)
            );
            services.AddValidatorsFromAssembly(
                typeof(CreateProductCommand).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
