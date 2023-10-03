using HotelGuestVerifyByPoliceAPI.Exceptions;
using HotelGuestVerifyByPoliceAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            int statusCode = StatusCodes.Status500InternalServerError;
            switch (ex)
            {
                case NotFoundException :
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                
            }

            var errorResonse = new ErrorResponse()
            { 
                StatusCode = statusCode,
                Message = ex.Message
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
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
