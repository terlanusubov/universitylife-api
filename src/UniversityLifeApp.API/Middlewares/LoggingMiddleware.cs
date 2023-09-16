using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UniversityLifeApp.Domain.Entities;

namespace UniversityLifeApp.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;
        private string logDirectoryPath;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger, IWebHostEnvironment Env)
        {
            _next = next;
            _logger = logger;
            _env = Env;
        }

        public async Task Invoke(HttpContext context)
        {
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

                DateTime currentDate = DateTime.Now;

                string logFileName = $"{currentDate:yyyy-MM}.log";

                string logFilePath = Path.Combine(_env.WebRootPath+"\\logging", logFileName);

                string logMessage = $"{currentDate:yyyy-MM-dd HH:mm:ss} | IpAdress: {clientIpAddress}, LogType: {logLevel}, Text: {(logLevel == LogLevel.Error ? "Server Error" : "Success")}, RequestType: {requestType}, Path: {path}";

                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}, LogType: Error, IpAdress: {clientIpAddress}";
                _logger.LogError(errorMessage);
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
