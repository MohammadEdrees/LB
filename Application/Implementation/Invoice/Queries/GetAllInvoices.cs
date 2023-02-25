using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Invoice.Queries
{
    public class GetAllInvoices:IRequest<IEnumerable<Domain.Entities.Invoices.Invoice>>
    {
        public class GetInvoicesHandler : IRequestHandler<GetAllInvoices, IEnumerable<Domain.Entities.Invoices.Invoice>>
        {
            private readonly IApplicationDbContext _context;

            public GetInvoicesHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Domain.Entities.Invoices.Invoice>> Handle(GetAllInvoices request, CancellationToken cancellationToken)
            {
                return await _context.Invoices.OrderByDescending(x=>x.Date).ToListAsync();
             }
        }
    }
}
