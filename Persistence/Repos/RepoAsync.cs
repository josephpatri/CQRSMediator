using Application.Interface;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repos
{
    public class RepoAsync<T> : RepositoryBase<T>, IAsyncRepo<T> where T : class
    {
        private readonly PetVetDbContext _context;

        public RepoAsync(PetVetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
