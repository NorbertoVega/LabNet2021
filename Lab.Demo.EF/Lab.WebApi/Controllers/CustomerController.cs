﻿using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        CustomersLogic customersLogic = new CustomersLogic();

        // GET api/values
        public IEnumerable<Customers> Get()
        {
            return customersLogic.GetAll();

        }

        // GET api/values/5
        public Customers Get(string id)
        {
            return customersLogic.GetAll().Where(c => c.CustomerID == id).ToList().First();
           
        }

        // POST api/values
        public void Post([FromBody] Customers customer)
        {
            customersLogic.Add(customer);
            
        }

        // PUT api/values/5
        public void Put(string id, [FromBody] Customers customer)
        {
            customersLogic.Update(new Customers
            {
                CustomerID = id,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax
            }); 

        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            customersLogic.Delete(new Customers { CustomerID = id });
          
        }
    }
}
