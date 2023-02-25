using Domain.Entities.Invoices;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice> Invoices { get; set; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
