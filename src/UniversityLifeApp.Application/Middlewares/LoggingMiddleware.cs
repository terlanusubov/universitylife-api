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
            //string requestMethod = context.Request.Method;
            //string requestPath = context.Request.Path;
            //string requestBody = await GetRequestBody(context.Request.Body);

            //_logger.LogInformation($"Incoming Request: {requestMethod} {requestPath}");
            //_logger.LogInformation($"Request Body: {requestBody}");

            //await _next(context);

            //var originalBodyStream = context.Response.Body;

            //using (var responseBody = new MemoryStream())
            //{
            //    context.Response.Body = responseBody;

            //    await _next(context);

            //    context.Response.Body.Seek(0, SeekOrigin.Begin);
            //    string responseContent = await new StreamReader(context.Response.Body).ReadToEndAsync();
            //    context.Response.Body.Seek(0, SeekOrigin.Begin);

            //    string requestMethodOutput = context.Request.Method;
            //    string requestPathOutput = context.Request.Path;
            //    //int responseStatusCode = context.Response.StatusCode;

            //    _logger.LogInformation($"Outgoing Response: {requestMethodOutput} {requestPathOutput}, Status Code: {responseStatusCode}");
            //    _logger.LogInformation($"Response Body: {responseContent}");

            //    await responseBody.CopyToAsync(originalBodyStream);
            //}

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
