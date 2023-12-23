using Application.Interface;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class PetVetDbContext : DbContext
    {
        public PetVetDbContext(DbContextOptions<PetVetDbContext> options, IDateTimeService service) 
            : base(options)
        {
            // We do this for clean information
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.service = service;
        }
        public DbSet<Customer> customers { get; set; }
        public IDateTimeService service { get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            foreach (var customer in ChangeTracker.Entries<BaseEntity>())
            {
                switch (customer.State)
                {
                    case EntityState.Modified:
                        customer.Entity.Modified = this.service.NowUtc;
                        break;
                    case EntityState.Added:
                        customer.Entity.Modified = this.service.NowUtc;
                        customer.Entity.Created = this.service.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellation);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
