namespace Application.ViewModels
{
    public class CreateInvoiceVM
    {
        public int InvoiceNum { get; set; }
        public byte PaymentMethod { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
    }
}
