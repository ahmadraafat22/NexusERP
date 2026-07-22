using FluentValidation;
using NexusERP.Application.Common.Exceptions;
using System.Text.Json;
namespace NexusERP.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "Not found",
                errors = new List<string>()
            };

            switch (ex)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = 400;
                    response = new
                    {
                        message = "Validation failed ",
                        errors = validationException.Errors
                        .Select(e => e.ErrorMessage)
                        .ToList()
                    };
                    break;
                case NotFoundException notFoundException:
                    context.Response.StatusCode = 404;
                    response = new
                    {
                        message = notFoundException.Message,
                        errors = new List<string>()
                    };
                    break;
                case UnauthorizedAccessException:
                    context.Response.StatusCode = 401;
                    response = new
                    {
                        message = "UnAuthorized",
                        errors = new List<string>()
                    };
                    break;
                default:
                    context.Response.StatusCode = 500;
                    break;

            }

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
