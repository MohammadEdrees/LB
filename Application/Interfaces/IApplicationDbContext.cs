using Domain.Entities.Invoices;
using Domain.Entities.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
