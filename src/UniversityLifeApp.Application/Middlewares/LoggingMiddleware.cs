using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

                LogLevel logLevel = DetermineLogLevel(requestBody, clientIpAddress, requestType);

                if (logLevel == LogLevel.Error)
                {
                    _logger.Log(logLevel, $"IpAdress: {clientIpAddress}, LogType: {logLevel}, Text: Server Error, RequestType: {requestType},Path :{path}");
                }
                else if (logLevel == LogLevel.Warning)
                {
                    _logger.Log(logLevel, $"IpAdress: {clientIpAddress}, LogType: {logLevel}, Text: Client Error, RequestType: {requestType},Path :{path}");

                }
                else if (logLevel == LogLevel.Information)
                {
                    _logger.Log(logLevel, $"IpAdress: {clientIpAddress}, LogType: {logLevel}, Text: Redirection Error, RequestType: {requestType},Path :{path}");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, LogType: Error, IpAdress: {clientIpAddress}");
            }

            await _next(context);
        }


        private LogLevel DetermineLogLevel(string requestBody, string clientIpAddress, string requestType)
        {
            if (requestBody.Contains("ERROR") || requestBody.Contains("Exception"))
            {
                return LogLevel.Error;
            }
            else if (requestType == "POST")
            {
                return LogLevel.Information;
            }
            else
            {
                return LogLevel.Warning;
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