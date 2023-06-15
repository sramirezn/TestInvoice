using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestInvoice.Models;

namespace TestInvoice.Data
{
    public class InvoiceRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public void CreateInvoice(InvoiceViewModel invoiceViewModel)
        {
            Invoice invoice = new Invoice
            {
                CustomerId = invoiceViewModel.SelectedCustomerId,
                TotalItbis = invoiceViewModel.InvoiceItems.Sum(i => i.TotalItbis),
                SubTotal = invoiceViewModel.InvoiceItems.Sum(i => i.SubTotal),
                Total = invoiceViewModel.InvoiceItems.Sum(i => i.Total),
            };

            _context.Invoice.Add(invoice);
             _context.SaveChanges();

            foreach (var item in invoiceViewModel.InvoiceItems)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail
                {
                    InvoiceId = invoice.Id, // Aquí inyectamos el ID del encabezado de la factura al detalle
                    Qty = item.Qty,
                    Price = item.Price,
                    TotalItbis = item.TotalItbis,
                    SubTotal = item.SubTotal,
                    Total = item.Total
                };

                _context.InvoiceDetails.Add(invoiceDetail);
            }

             _context.SaveChanges();





        }

            public IEnumerable<Invoice> GetAllInvoices()
        {
            return _context.Invoice.ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            var invoice = _context.Invoice.Include(i => i.InvoiceDetails).FirstOrDefault(m => m.Id == id);
            return invoice;
        }

        public void AddInvoice(Invoice invoice)
        {
            _context.Invoice.Add(invoice);
            _context.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _context.Invoice.Remove(invoice);
            _context.SaveChanges();
        }
    }
}