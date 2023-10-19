
using HotelGuestVerifyByPoliceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Security.Cryptography.Xml;

namespace HotelGuestVerifyByPoliceAPI.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong");
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            int statuscode = 0;
            var errorResonse = new ErrorResponse()
            {
                status = "error",
            };
            switch (ex)
            {
               
                case ApplicationException:
                    errorResonse.StatusCode = (int)HttpStatusCode.Forbidden;
                    errorResonse.status = "error";
                    errorResonse.Message = "Something Went Wrong In Application.";
                    break;
                case SqlException:
                    errorResonse.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResonse.status = "error";
                    errorResonse.Message = "Database exception occurred.";
                    break;
                case TimeoutException:
                    errorResonse.StatusCode = StatusCodes.Status408RequestTimeout;
                    errorResonse.status = "error";
                    errorResonse.Message = "Database timeout exception occurred.";
                    break;
                default:
                    errorResonse.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResonse.status = "error";
                    errorResonse.Message = "Internal Server Error.";
                    break;

            }
            context.Response.ContentType = "application/json";
            //context.Response.StatusCode = statuscode;
            return context.Response.WriteAsync(errorResonse.ToString());

        }
    }

    //Extension method for middleware
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>(); 
        }
    }
}
