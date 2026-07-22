using Microsoft.AspNetCore.Identity;
using NexusERP.Application;
using NexusERP.Infrasructure;
using NexusERP.WebApi;
using NexusERP.WebApi.Middlewares;

namespace NexusERP
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // application services after dependency Injection 
            builder.Services.AddApplication();
            // Infrastructure services after dependency Injection 
            builder.Services.AddInfrastructure(builder.Configuration);
            // WebApi services after dependency Injection 
            builder.Services.AddWebApi();

            var app = builder.Build();

            // adding Roles 
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
