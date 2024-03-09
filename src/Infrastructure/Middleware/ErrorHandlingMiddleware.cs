using Domain.Exceptions;
using Domain.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
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
            catch (SqlException ex)
            {
                await HandleExceptionAsync(context, new DataBaseException(ex.Procedure, null, ex.Message));
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
                    errorMessage = "An internal error has occurred.";
                    break;
                case DataBaseException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "A database error has occurred.";
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
                    errorMessage = "An unknown error has occurred.";
                    break;
            }
            
            var response = new ErrorResponse(Guid.NewGuid().ToString().ToUpper(), errorMessage);

            var jsonResponse = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
