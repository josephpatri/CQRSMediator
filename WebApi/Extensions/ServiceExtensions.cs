using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiExtensions(this IServiceCollection services)
        {
            services.AddApiVersioning(conf =>
            {
                conf.DefaultApiVersion = new ApiVersion(1,0);
                conf.AssumeDefaultVersionWhenUnspecified = true;
                conf.ReportApiVersions = true;
            });
        }
    }
}