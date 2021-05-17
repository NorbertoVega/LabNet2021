using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class ProductController : Controller
    {
        ProductsLogic productLogic = new ProductsLogic();

        // GET: Product
        public ActionResult Index()
        {
            try
            {
                List<Products> products = productLogic.GetAll();

                List<ProductView> productsView = products.Select(p => new ProductView
                {
                    Id = p.ProductID,
                    Name = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock
                }).ToList();

                return View(productsView);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { message = $"Descripción de error: {e.Message}" });
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductView productView)
        {
            if (productView == null)
            {
                return RedirectToAction("Index", "Error", new { message = $"Descripción de error: ningún campo fue completado" });

            }

            try
            {
                Products productEntity = new Products
                {   
                    ProductName = productView.Name,
                    UnitPrice = productView.UnitPrice,
                    UnitsInStock = productView.UnitsInStock
                };

                productLogic.Add(productEntity);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { message = $"Descripción de error: {e.Message}" });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                productLogic.Delete(new Products { ProductID = id });

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { message = $"Descripción de error: {e.Message}" });

            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, ProductView productView)
        {
            try
            {
                productLogic.Update(new Products
                {
                    ProductID = id,
                    ProductName = productView.Name,
                    UnitPrice = productView.UnitPrice,
                    UnitsInStock = productView.UnitsInStock
                });

                return RedirectToAction("Index");
            }
            catch (Exception  e)
            {
                return RedirectToAction("Index", "Error", new { message = $"Descripción de error: {e.Message}" });
            }
        }
    }
}