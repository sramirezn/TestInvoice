using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestInvoice.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=Test_InvoiceConnectionString")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

       
    }
}