using Domain.Common;
using Domain.Entities.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Invoices
{
    public class Invoice
    {
        public Invoice()
        {
            Items = new HashSet<Item>();  
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceNum { get; set; }
        public byte PaymentMethod { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Item> Items { set; get; }
    }
}
