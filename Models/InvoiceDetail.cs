using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestInvoice.Models
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InvoiceId { get; set; } // Este campo es necesario para establecer la relación con Invoice

        [Required]
        public int Qty { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalItbis { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal Total { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}