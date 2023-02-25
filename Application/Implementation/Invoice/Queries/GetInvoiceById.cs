using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                 return await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceNum == query.Id);
                    
             }
        }
    }
}
