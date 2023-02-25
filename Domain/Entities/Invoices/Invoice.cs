using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Invoices
{
    public class Invoice
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceNum { get; set; }
        public byte PaymentMethod { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
    }
}
