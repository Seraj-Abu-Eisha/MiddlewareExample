using MiddlewareExample.CustomeMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomeMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("First Middleware\n");
    await next(context);
});
app.UseMyCustomMiddleware();
app.UseHelloMiddleware();


app.Run(async (HttpContext context) =>  
{
    await context.Response.WriteAsync("Second Middleware\n");
});
app.Run();
