using Lab.EF.Entities;
using Lab.EF.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        ProductsLogic productLogic = new ProductsLogic();

        // GET api/values
        public IEnumerable<Products> Get()
        {           
            return productLogic.GetAll();
        
        }

        // GET api/values/5
        public Products Get(int id)
        {
            return productLogic.GetAll().Where(p => p.ProductID == id).ToList().First();
            
        }

        // POST api/values
        public void Post([FromBody] Products product)
        {          
            productLogic.Add(product);
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Products product)
        {
            productLogic.Update(new Products
            {
                ProductID = id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            });
           
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            productLogic.Delete(new Products { ProductID = id });
            
        }
    }
}