using Application.Interfaces;
using Domain.Entities.Invoices;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDBContext : DbContext , IApplicationDbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {

        }
        public DbSet<Invoice> Invoices { get; set; }
 
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
