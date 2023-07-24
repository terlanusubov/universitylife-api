using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.Middlewares
{
    public class InputLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<InputLoggingMiddleware> _logger;

        public InputLoggingMiddleware(RequestDelegate next, ILogger<InputLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestMethod = context.Request.Method;
            string requestPath = context.Request.Path;
            string requestBody = await GetRequestBody(context.Request.Body);

            _logger.LogInformation($"Incoming Request: {requestMethod} {requestPath}");
            _logger.LogInformation($"Request Body: {requestBody}");

            await _next(context);
        }

        private async Task<string> GetRequestBody(Stream body)
        {
            using (StreamReader reader = new StreamReader(body, Encoding.UTF8, true, 1024, true))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
