using Application.Interfaces;
using MediatR;

namespace Application.Implementation.Invoice.Commands
{
    public class UpdateInvoice:IRequest<int>
    {
        public int InvoiceNum { get; set; }
        public byte PaymentMethod { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }

        public class UpdateInvoideHandler : IRequestHandler<UpdateInvoice, int>
        {
            private readonly IApplicationDbContext _context;

            public async Task<int> Handle(UpdateInvoice invoice, CancellationToken cancellationToken)
            {
                Domain.Entities.Invoices.Invoice InvoiceFound = await _context.Invoices.FindAsync(invoice.InvoiceNum);
                if (InvoiceFound != null)
                {
                    InvoiceFound.Date = invoice.Date;
                    InvoiceFound.PaymentMethod = invoice.PaymentMethod;
                    InvoiceFound.Description = invoice.Description;
                    InvoiceFound.Customer = invoice.Customer;
                    
                    return await _context.SaveChangesAsync();   
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
