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
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al agregar el producto");
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
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("El producto que se quiere eliminar no existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al eliminar el producto");
            }
        }

        public void Update(Products product)
        {
            try
            {
                var productUpdate = context.Products.Find(product.ProductID);

                productUpdate.ProductName = product.ProductName;
                context.SaveChanges();

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("El producto que se quiere actualizar no existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al actualizar el producto");
            }
        }
    }
}
