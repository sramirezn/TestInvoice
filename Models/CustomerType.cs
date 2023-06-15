using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestInvoice.Models
{
    [Table("CustomerTypes")]
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Description { get; set; }

    }
}