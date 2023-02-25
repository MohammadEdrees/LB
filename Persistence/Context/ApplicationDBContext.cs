using Application.Interfaces;
using Domain.Entities.Invoices;
using Domain.Entities.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDBContext : DbContext , IApplicationDbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {

        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set ; }

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
