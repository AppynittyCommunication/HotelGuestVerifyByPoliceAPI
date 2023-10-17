using Newtonsoft.Json;

namespace HotelGuestVerifyByPoliceAPI.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private
        const string APIKEY = "XApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out
                    var extractedApiKey))
            {
                //context.Response.StatusCode = 401;
                //context.Response.ContentType = "text/plain";
                //await context.Response.WriteAsync("{\"error\": \"Api Key was not provided\"}");

                SendError(context, 401, "Api Key was not provided");
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEY);
            if (!apiKey.Equals(extractedApiKey))
            {
                //context.Response.StatusCode = 401;
                //context.Response.ContentType = "text/plain";
                //await context.Response.WriteAsync("{\"error\": \"Unauthorized client\");
                SendError(context, 401, "Unauthorized client");
                return;
            }
            await _next(context);
        }

        private void SendError(HttpContext context, int statusCode, string errorMessage)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var errorResponse = new
            {
                code = statusCode,
                status = "error",
                message = errorMessage
            };
            string jsonError = JsonConvert.SerializeObject(errorResponse);
            context.Response.WriteAsync(jsonError);
        }
    }
}
