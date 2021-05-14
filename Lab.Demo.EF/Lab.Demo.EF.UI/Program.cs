using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;
using Lab.EF.Logic;

namespace Lab.Demo.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {   
            ProductsLogic productsLogic = new ProductsLogic();
            
            ShowProducts(productsLogic);

            Products product = new Products { 
                ProductName = "New Product",
                UnitPrice = 15000
            };

            productsLogic.Add(product);
            ShowProducts(productsLogic);

            productsLogic.Update(new Products
            {
                ProductID = product.ProductID,
                ProductName = "New name"
            });
            ShowProducts(productsLogic);
            
            productsLogic.Delete(product);
            ShowProducts(productsLogic);
            
            CustomersLogic customersLogic = new CustomersLogic();

            Showcustomers(customersLogic);

            Customers customer = new Customers
            {
                CustomerID = "ZZZZZ",
                CompanyName = "New Company",
                Address = "Fake Street 123"
            };

            customersLogic.Add(customer);
            Showcustomers(customersLogic);

            customersLogic.Update(new Customers
            {
                CustomerID = customer.CustomerID,
                CompanyName = "Company name updated"
            });
            Showcustomers(customersLogic);

            customersLogic.Delete(customer);
            Showcustomers(customersLogic);


            Console.ReadLine();

        }

        public static void ShowProducts(ProductsLogic productsLogic) 
        {
            try
            {
                Console.WriteLine("Products: ");

                foreach (var product in productsLogic.GetAll())
                {
                    Console.WriteLine($"{product.ProductID} - {product.ProductName}  - {product.UnitPrice}");
                }

                Console.WriteLine("\n");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("La lista de productos es vacia");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al cargar la lista de productos");
            }
        }

        public static void Showcustomers(CustomersLogic customersLogic)
        {
            try 
            { 
                Console.WriteLine("Customers:");

                foreach (var customer in customersLogic.GetAll())
                {
                    Console.WriteLine($"{customer.CustomerID} - {customer.CompanyName}  - {customer.Address} - {customer.ContactName}");
                }

                Console.WriteLine("\n");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("La lista de customers es vacia");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al cargar la lista de customers");
            }
        }

    }
}
