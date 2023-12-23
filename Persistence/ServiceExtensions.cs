using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repos;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfra(this IServiceCollection service,
                IConfiguration configuration)
        {
            service.AddDbContext<PetVetDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly(typeof(PetVetDbContext).Assembly.FullName)
                );
            });

            service.AddTransient(typeof(IAsyncRepo<>), typeof(RepoAsync<>));
        }
    }
}
