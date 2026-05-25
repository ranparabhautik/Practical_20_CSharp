using Practical_20.Logging;
using Microsoft.IdentityModel.Logging;

namespace Practical_20.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,Logger logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await logger.Log(ex.Message, "Error");

            await HandleException(context, ex);
        }
    }

    private static Task HandleException(HttpContext context,Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        var response = new
        {
            message = "Some error happened",
            detail = ex.Message
        };
        return context.Response.WriteAsJsonAsync(response);
    }
}