using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace Middlewares.Middlewares
{
    public class HelloMiddleware
    {
        RequestDelegate _next;
        ILogger _logger;
        public HelloMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Custom operasyon
            _logger.LogInformation("Selamın Aleyküm.");
            _logger.LogInformation($"HttpContext Request Method: {httpContext.Request.Method} - Path:{httpContext.Request.Path} - Body: {httpContext.Request.Body} - Host: {JsonSerializer.Serialize(httpContext.Request.Host)}  ");
            Console.WriteLine("Selamın Aleyküm.");
            await _next.Invoke(httpContext); // Bunu yapmazsam short circuit olur. Bundan sonraki middleware ler devam edemez .
            _logger.LogInformation($"HttpContext Response StatusCode: {httpContext.Response.StatusCode} - Response:{httpContext.Response.ToString()} - Body: {httpContext.Request.Body} ");
            _logger.LogInformation("Aleyküm Selam");
            Console.WriteLine("Aleyküm Selam");
        }
    }
}
