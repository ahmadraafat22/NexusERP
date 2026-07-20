using FluentValidation;
using NexusERP.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;
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
                        .Select(e => e.ErrorMessage)
                        .ToList()
                    };
                    break;

                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)StatusCodes.Status404NotFound;
                    response = new
                    {
                        message = notFoundException.Message,
                        errors = new List<string>()
                    };
                    break;

                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = new
                    {
                        message = "Unauthorized",
                        errors = new List<string>()
                    };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
