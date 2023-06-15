using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestInvoice.Models;

namespace TestInvoice.Data
{
   
    public class CustomerTypeRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public IEnumerable<CustomerType> GetAllCustomerTypes()
        {
            return _context.CustomerTypes.ToList();
        }

        public CustomerType GetCustomerTypeById(int id)
        {
            return _context.CustomerTypes.Find(id);
        }

        public void AddCustomerType(CustomerType customerType)
        {
            _context.CustomerTypes.Add(customerType);
            _context.SaveChanges();
        }

        public void UpdateCustomerType(CustomerType customerType)
        {
            _context.Entry(customerType).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCustomerType(CustomerType customerType)
        {
            _context.CustomerTypes.Remove(customerType);
            _context.SaveChanges();
        }
    }
}