using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInvoice.Data;
using TestInvoice.Models;

namespace TestInvoice.Controllers
{
    public class InvoiceController : Controller
    {
        private CustomerTypeRepository _customerTypeRepository = new CustomerTypeRepository();
        private CustomerRepository _customerRespository = new CustomerRepository();
        private InvoiceRepository _invoiceRepository = new InvoiceRepository();

        // GET: Invoice
        public ActionResult Index()
        {
                var invoices = _invoiceRepository.GetAllInvoices();
                return View(invoices);
            
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
          
            var invoice = _invoiceRepository.GetInvoiceById(id);

            if (invoice == null)
                return HttpNotFound();

            return View(invoice);
        }
        public ActionResult Create()
        {
            var customer = _customerRespository.GetAllCustomers();
            ViewBag.CustomerId = new SelectList(customer, "Id", "CustName");

         
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceViewModel model)
        {
            _invoiceRepository.CreateInvoice(model);

            return RedirectToAction("Index", "Home");
        }


    }
}