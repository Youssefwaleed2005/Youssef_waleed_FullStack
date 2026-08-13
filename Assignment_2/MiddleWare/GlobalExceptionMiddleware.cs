using Assignment_3.Exceptions;
using Microsoft.AspNetCore.Mvc;
namespace Assignment_3.MiddleWare
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;


        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                Console.WriteLine("Middleware");
                await _next(context);
            }
            catch (NotFoundException)
            {
                WriteProblemDetails(context, 404, "Not found", "Id not found");
            }
            catch (ConflictException)
            {
                WriteProblemDetails(context, 409, "Conflict exeption", "Title already exists");
            }
        }
        public async Task WriteProblemDetails(HttpContext ctx, int status, string title, string detail)
        {
            ctx.Response.StatusCode = status;
            ctx.Response.ContentType = "application/problem+json";
            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail
            };

            await ctx.Response.WriteAsJsonAsync(problem);
        }
    }
}
