using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareExample.CustomeMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HelloCustomeMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("firstname")
            && httpContext.Request.Query.ContainsKey("lastname"))
            {
               string fullname = httpContext.Request.Query["firstname"] + " "
                    + httpContext.Request.Query["lastname"];
                httpContext.Response.WriteAsync(fullname);
            }
            return _next(httpContext);
            //after logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomeMiddleware>();
        }
    }
}
