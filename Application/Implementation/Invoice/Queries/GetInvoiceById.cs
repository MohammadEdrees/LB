using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation.Invoice.Queries
{
    public class GetInvoiceById:IRequest<Domain.Entities.Invoices.Invoice>
    {
        public int Id { get; set; }

        public class GetInvoiceHandler : IRequestHandler<GetInvoiceById, Domain.Entities.Invoices.Invoice>
        {
            private readonly IApplicationDbContext _context;

            public async Task<Domain.Entities.Invoices.Invoice> Handle(GetInvoiceById query, CancellationToken cancellationToken)
            {
                return null;
               // return await _context.Invoices.FirstOrDefaultAsync(i => i.Id == query.Id);
                    
             }
        }
    }
}
