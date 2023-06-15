using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestInvoice.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string CustName { get; set; }

        [Required]
        [StringLength(120)]
        public string Adress { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        public virtual CustomerType CustomerType { get; set; }
       
    }
}