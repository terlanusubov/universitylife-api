using MediatR.Pipeline;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Enums;

namespace UniversityLifeApp.Application.Behaviours
{
    public class RequestExceptionBehavior<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : Exception
    {
        private readonly ILogger<RequestExceptionBehavior<TRequest,TResponse,TException>> _logger;
        private readonly IWebHostEnvironment _env;

        public RequestExceptionBehavior(ILogger<RequestExceptionBehavior<TRequest, TResponse, TException>> logger,
                             IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {


            DateTime currentDate = DateTime.Now;

            string logFileName = $"{currentDate:yyyy-MM}.log";

            string logFilePath = Path.Combine(_env.WebRootPath + "\\logging", logFileName);

            StringBuilder builder = new StringBuilder();

            builder.Append($"EXCEPTION OCCURED : {exception.Message}\n");

            File.AppendAllText(logFilePath, builder.ToString() + Environment.NewLine);


            var responseType = typeof(TResponse);

            var response = Activator.CreateInstance(typeof(TResponse));

            var errorMethod = response.GetType().GetMethod("Error");

            state.SetHandled((TResponse)errorMethod.Invoke(response, new object[] { ErrorCodes.INTERNAL_SERVER_ERROR, null, HttpStatusCode.InternalServerError }));
        }
    }
}
