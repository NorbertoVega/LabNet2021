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

            foreach (Products product in productsLogic.GetAll())
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
            }

            Console.ReadLine();
        }
    }
}
