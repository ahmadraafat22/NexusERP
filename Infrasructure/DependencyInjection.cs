using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NexusERP.Domain.Entities;
using NexusERP.Domain.Interfaces;
using NexusERP.Infrasructure.Persistence;
using NexusERP.Infrasructure.Services;
using System.Text;

namespace NexusERP.Infrasructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // add db connection string and inject AppDbcontext 
            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("cs"))
            );

            // register appUsere  and identityRole in database
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            // register Jwt service in ioc 
            services.AddScoped<IJwtService, JwtService>();

            // add authantication jwt settings
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["JWT:Iss"],
                    ValidateAudience = true,
                    ValidAudience = config["JWT:Aud"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])),
                    ValidateLifetime = true

                };

            });
            services.AddScoped<ICodeGeneratorService, CodeGeneratorService>();
            return services;
        }
    }
}
