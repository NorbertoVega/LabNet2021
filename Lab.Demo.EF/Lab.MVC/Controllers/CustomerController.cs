﻿using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomersLogic customersLogic = new CustomersLogic();

        // GET: Customer
        public ActionResult Index()
        {
            try
            {
                List<Customers> customers = customersLogic.GetAll();
                List<CustomerView> customerViews = customers.Select(c => new CustomerView
                {
                    ID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    Address = c.Address,
                    Phone = c.Phone
                }).ToList();

                return View(customerViews);
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomerView customerView)
        {
            try
            {
                Customers productEntity = new Customers
                {
                    CustomerID = customerView.ID,
                    CompanyName = customerView.CompanyName,
                    Address = customerView.Address,
                    Phone = customerView.Phone

                };

                customersLogic.Add(productEntity);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                customersLogic.Delete(new Customers { CustomerID = id });

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");

            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(string id, CustomerView customerView)
        {
            try
            {
                customersLogic.Update(new Customers
                {
                    CustomerID = id,
                    CompanyName = customerView.CompanyName,
                    Address = customerView.Address,
                    Phone = customerView.Phone
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

    }
}