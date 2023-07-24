using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.Middlewares
{
    public class OutputLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<OutputLoggingMiddleware> _logger;

        public OutputLoggingMiddleware(RequestDelegate next, ILogger<OutputLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Yanıtın bilgilerini logla
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                string responseContent = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                string requestMethod = context.Request.Method;
                string requestPath = context.Request.Path;
                int responseStatusCode = context.Response.StatusCode;

                _logger.LogInformation($"Outgoing Response: {requestMethod} {requestPath}, Status Code: {responseStatusCode}");
                _logger.LogInformation($"Response Body: {responseContent}");

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }
}
