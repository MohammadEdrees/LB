using Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ItemVM
    {
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
