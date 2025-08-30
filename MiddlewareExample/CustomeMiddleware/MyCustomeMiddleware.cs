
namespace MiddlewareExample.CustomeMiddleware
{
    public class MyCustomeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom middleware - start\n");
            await next(context);
            await context.Response.WriteAsync("My custom middleware - ends\n");
        }
    }
    public static class CustomMiddlewareExtenstions
    {
        public static IApplicationBuilder UseMyCustomMiddleware
            (this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomeMiddleware>();
        }
    }
}
