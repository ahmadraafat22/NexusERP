
using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
namespace NexusERP.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context,ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context , Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "Somthing went wrong",
                errors = new List<string> { ex.Message } 
            };

            switch (ex)
            {
                case ValidationException validationException:
                    context.Response.StatusCode =
                       (int)HttpStatusCode.BadRequest;
                    response = new
                    {
                        message = "Validation failed",
                        errors = validationException
                        .Errors
                        .Select(e=>e.ErrorMessage)
                        .ToList()
                    };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            
            }
            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
