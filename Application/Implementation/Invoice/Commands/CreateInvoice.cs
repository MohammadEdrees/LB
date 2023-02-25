using Application.Interfaces;
using Domain.Entities.Items;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Implementation.Invoice.Commands
{
    public class CreateInvoice:IRequest<int>
    {

        public int InvoiceNum { get; set; }
        public byte PaymentMethod { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Item> Items { set; get; }


        public class CreateInvoiceHandler : IRequestHandler<CreateInvoice, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateInvoiceHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateInvoice invoice, CancellationToken cancellationToken)
            {
                 EntityEntry<Domain.Entities.Invoices.Invoice> CreatedInvoice = await _context.Invoices.AddAsync(new Domain.Entities.Invoices.Invoice
                {
                    InvoiceNum = invoice.InvoiceNum,
                    Date =invoice.Date,
                    Customer= invoice.Customer,
                    Description=invoice.Description,
                    PaymentMethod=invoice.PaymentMethod,    
                    Items=invoice.Items

                });
                await _context.SaveChangesAsync();
                return CreatedInvoice.Entity.InvoiceNum;
            }
        }
    }
}
