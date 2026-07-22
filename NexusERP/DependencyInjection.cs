using Microsoft.AspNetCore.Mvc;

namespace NexusERP.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", optionbuilder =>
                {
                    optionbuilder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            // cancel asp.net core defualt validation 
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
