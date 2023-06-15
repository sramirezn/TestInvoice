using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInvoice.Data;
using TestInvoice.Models;

namespace TestInvoice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private CustomerTypeRepository _customerTypeRepository = new CustomerTypeRepository();
        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        public ActionResult Index()
        {
            var customers = _customerRepository.GetAllCustomers().ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            var customerTypes = _customerTypeRepository.GetAllCustomerTypes();
            ViewBag.CustomerTypes = new SelectList(customerTypes, "Id", "Description");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            var customerTypes = _customerTypeRepository.GetAllCustomerTypes();
            ViewBag.CustomerTypes = new SelectList(customerTypes, "Id", "Description");

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return HttpNotFound();

            var customerTypes = _customerTypeRepository.GetAllCustomerTypes();
            ViewBag.CustomerTypes = new SelectList(customerTypes, "Id", "Description", customer.CustomerTypeId);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }

            var customerTypes = _customerTypeRepository.GetAllCustomerTypes();
            ViewBag.CustomerTypes = new SelectList(customerTypes, "Id", "Description", customer.CustomerTypeId);

            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return HttpNotFound();

            _customerRepository.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }




    }
}
