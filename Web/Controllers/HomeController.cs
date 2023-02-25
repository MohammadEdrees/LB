using Application.Implementation.Invoice.Commands;
using Application.Implementation.Invoice.Queries;
using Domain.Entities.Invoices;
using Domain.Entities.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
             
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Create()
        {
            Item item1 = new Item
            {
                ItemName = "item1 for test",
                Price = 150,
                Qty = 4
            };
            Item item2 = new Item
            {
                ItemName = "item2 for test",
                Price = 200,
                Qty = 45
            };
            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            CreateInvoice createInvoice = new CreateInvoice
            {
                Customer = "Ahmed2",
                Date = DateTime.Now,
                Description = "test2",
                PaymentMethod = 1,
                Items=items
                
            };
            int v = await  Mediator.Send(createInvoice);
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Invoice> enumerable = await  Mediator.Send(new GetAllInvoices());
            return View();
        }
        public async Task<IActionResult> GetById(int Id)
        {
            await  Mediator.Send(new GetInvoiceById { Id =Id});
            return View();
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await  Mediator.Send(new DeleteInvoice{ Id =Id});
            return View();
        }


    }
}