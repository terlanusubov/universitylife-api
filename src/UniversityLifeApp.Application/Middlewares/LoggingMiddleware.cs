using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Capture the client's IP address
            string clientIpAddress = context.Connection.RemoteIpAddress?.ToString();

            try
            {
                // Capture the request body text
                string requestBody = await GetRequestBody(context.Request.Body);

                // Log the request body and client IP
                _logger.LogInformation($"Client IP: {clientIpAddress}, Request Body: {requestBody}");
            }
            catch (Exception ex)
            {
                // Log the error message and client IP
                _logger.LogError($"Client IP: {clientIpAddress}, Error: {ex.Message}");
            }

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
