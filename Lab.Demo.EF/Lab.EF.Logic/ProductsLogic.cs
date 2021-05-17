using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ProductsLogic: BaseLogic, IABMLogic<Products>
    {
        public List<Products> GetAll()
        {                     
                return context.Products.ToList();                  
        }

        public void Add(Products newProduct)
        {
            try
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Products product)
        {
            try
            {
                var productDelete = context.Products.Find(product.ProductID);

                context.Products.Remove(productDelete);
                context.SaveChanges();

            }
            catch 
            {
                throw;
            }
         
        }

        public void Update(Products product)
        {
            try
            {
                var productUpdate = context.Products.Find(product.ProductID);

                productUpdate.ProductName = product.ProductName;
                productUpdate.SupplierID = product.SupplierID;
                productUpdate.CategoryID = product.CategoryID;
                productUpdate.QuantityPerUnit = product.QuantityPerUnit;
                productUpdate.UnitPrice = product.UnitPrice;
                productUpdate.UnitsInStock = product.UnitsInStock;
                productUpdate.UnitsOnOrder = product.UnitsOnOrder;
                productUpdate.ReorderLevel = product.ReorderLevel;
                productUpdate.Discontinued = product.Discontinued;
                 
                context.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
