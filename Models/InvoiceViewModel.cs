using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestInvoice.Models
{
    public class InvoiceViewModel
    {
        public int SelectedCustomerId { get; set; }
        public List<InvoiceDetail> InvoiceItems { get; set; }

        public InvoiceViewModel()
        {
           
            InvoiceItems = new List<InvoiceDetail>();

          
        }
    }
}