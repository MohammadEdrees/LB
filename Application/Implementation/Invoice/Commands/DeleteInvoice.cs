using Application.Interfaces;
using MediatR;

namespace Application.Implementation.Invoice.Commands
{
    public class DeleteInvoice:IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoice, int>
        {
            private readonly IApplicationDbContext _context;

            public DeleteInvoiceHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteInvoice invoice, CancellationToken cancellationToken)
            {
                Domain.Entities.Invoices.Invoice InvoiceFound = await _context.Invoices.FindAsync(invoice.Id);
                if(InvoiceFound != null)
                {
                    _context.Invoices.Remove(InvoiceFound);
                }
                else
                {
                    return default;
                }
                return await _context.SaveChangesAsync();
            }
        }

    }
}
