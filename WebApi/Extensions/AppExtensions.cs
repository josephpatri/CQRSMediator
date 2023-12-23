using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Middlewares;

namespace WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandler>();
        }
    }
}
