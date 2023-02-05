using Microsoft.AspNetCore.Builder;
using Middlewares.Middlewares;

namespace Middlewares.Extensions
{
    static public class Extension
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<HelloMiddleware>();
        }
    }
}
