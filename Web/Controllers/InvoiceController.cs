using Application.Implementation.Invoice.Commands;
using Application.Implementation.Invoice.Queries;
using Application.ViewModels;
using Domain.Entities.Invoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class InvoiceController:Controller
    {
        private readonly IMediator _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        public async Task<IActionResult> Index()
        {
            IEnumerable<Invoice> Invoices = await Mediator.Send(new GetAllInvoices());

            return View(Invoices);
        }
         
        public async Task<IActionResult> Delete(int num)
        {
            await Mediator.Send(new DeleteInvoice { Id=num});
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceVM createInvoice)
        {
            await Mediator.Send(new CreateInvoice
            {
                InvoiceNum= createInvoice.InvoiceNum,   
                Customer= createInvoice.Customer,
                Date= createInvoice.Date,
                Description= createInvoice.Description,
                PaymentMethod= createInvoice.PaymentMethod,

            });
            return RedirectToAction(nameof(Index));
        }
         

    }
}
