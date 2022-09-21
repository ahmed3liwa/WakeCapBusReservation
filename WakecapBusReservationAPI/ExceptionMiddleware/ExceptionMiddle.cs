using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Exceptions;

namespace WakecapBusReservation.API.ExceptionMiddleware
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddleWare(
            RequestDelegate next,
            ILogger<ExceptionMiddleWare> logger,
            IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex is BusinessException)
                {
                    BusinessException bEx = ex as BusinessException;
                    ex = ex as BusinessException;
                    errorMessage = bEx.ExMessage;
                }

                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ErrorResponseViewModel(errorMessage);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsync(json);

            }
        }
    }
}
