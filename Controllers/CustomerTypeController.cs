using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestInvoice.Data;
using TestInvoice.Models;

namespace TestInvoice.Controllers
{
    public class CustomerTypeController : Controller
    {
        private CustomerTypeRepository _customerTypeRepository = new CustomerTypeRepository();

        public ActionResult Index()
        {
            var customerTypes = _customerTypeRepository.GetAllCustomerTypes().ToList();
            return View(customerTypes);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepository.AddCustomerType(customerType);
                return RedirectToAction("Index");
            }

            return View(customerType);
        }

        public ActionResult Edit(int id)
        {
            var customerType = _customerTypeRepository.GetCustomerTypeById(id);

            if (customerType == null)
                return HttpNotFound();
           

            return View(customerType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerType customerType)
        {
            if (id != customerType.Id)
                 return HttpNotFound();
            
            if (ModelState.IsValid)
            {
                _customerTypeRepository.UpdateCustomerType(customerType);
                return RedirectToAction("Index");
            }

            return View(customerType);
        }

        public ActionResult Delete(int id)
        {
            var customerType = _customerTypeRepository.GetCustomerTypeById(id);

            if (customerType == null)
                return HttpNotFound();
           
            return View(customerType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customerType = _customerTypeRepository.GetCustomerTypeById(id);

            if (customerType == null)
                return HttpNotFound();
     

            _customerTypeRepository.DeleteCustomerType(customerType);
            return RedirectToAction("Index");
        }

    }
}