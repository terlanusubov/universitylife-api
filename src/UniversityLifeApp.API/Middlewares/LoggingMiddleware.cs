using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UniversityLifeApp.API.Middlewares
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
            // Capture the client's IP address from X-Forwarded-For header, or use default if not available
            string clientIpAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(clientIpAddress))
            {
                clientIpAddress = context.Connection.RemoteIpAddress.ToString();
            }

            try
            {
                string requestType = context.Request.Method;
                string path = context.Request.Path;
                string requestBody = await GetRequestBody(context.Request.Body);

                LogLevel logLevel = DetermineLogLevel(context);

                if (logLevel == LogLevel.Error)
                {
                    _logger.LogError($"IpAdress: {clientIpAddress}, LogType: {logLevel}, Text: Server Error, RequestType: {requestType}, Path: {path}");
                }
                else if (logLevel == LogLevel.Information)
                {
                    _logger.LogInformation($"IpAdress: {clientIpAddress}, LogType: {logLevel}, Text: Success, RequestType: {requestType}, Path: {path}");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, LogType: Error, IpAdress: {clientIpAddress}");
            }

            await _next(context);
        }

        private LogLevel DetermineLogLevel(HttpContext context)
        {
            int statusCode = context.Response.StatusCode;

            if (statusCode >= 400 && statusCode <= 599)
            {
                return LogLevel.Error;
            }
            else
            {
                return LogLevel.Information;
            }
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
