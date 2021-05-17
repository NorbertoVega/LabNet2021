using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers customer)
        {
            try 
            { 
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Customers customer)
        {
            try
            {
                var customerDelete = context.Customers.Find(customer.CustomerID);
                context.Customers.Remove(customerDelete);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
          
        }

        public void Update(Customers customer)
        {
            try 
            { 
                var customerUpdate = context.Customers.Find(customer.CustomerID);
                customerUpdate.CompanyName = customer.CompanyName;
                customerUpdate.ContactName = customer.ContactName;
                customerUpdate.ContactTitle = customer.ContactTitle;
                customerUpdate.Address = customer.Address;
                customerUpdate.City = customer.City;
                customerUpdate.Region = customer.Region;
                customerUpdate.PostalCode = customer.PostalCode;
                customerUpdate.Country = customer.Country;
                customerUpdate.Phone = customer.Phone;
                customer.Fax = customer.Fax;

                context.SaveChanges();
            }
            catch
            {
                throw;
            }
    
        }
    }
}
