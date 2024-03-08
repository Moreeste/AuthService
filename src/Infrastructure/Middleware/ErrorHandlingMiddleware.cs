using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string errorMessage;

            switch (exception)
            {
                case SysException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "Internal System Error";
                    break;
                case DataBaseException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "DataBase Error";
                    break;
                case BusinessException:
                    statusCode = StatusCodes.Status400BadRequest;
                    errorMessage = exception.Message;
                    break;
                case SearchException:
                    statusCode = StatusCodes.Status404NotFound;
                    errorMessage = exception.Message;
                    break;
                case CustomValidationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    errorMessage = exception.Message;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "Unknown Error";
                    break;
            }

            var response = new { StatusCode = statusCode, Message = errorMessage };
            var jsonResponse = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
