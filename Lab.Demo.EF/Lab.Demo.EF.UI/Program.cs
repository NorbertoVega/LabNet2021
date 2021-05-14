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
        {   /*
            ProductsLogic productsLogic = new ProductsLogic();

            foreach (Products product in productsLogic.GetAll())
            {
                Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
            }

            Console.ReadLine();
            */

            RegionLogic regionLogic = new RegionLogic();

            foreach (var region in regionLogic.GetAll())
            {
                Console.WriteLine($"{region.RegionID} - {region.RegionDescription}");
            }

            /*
            regionLogic.Add(new Region { 
                RegionID = 10,
                RegionDescription = "Sarasa"
            }); 

            regionLogic.Delete(10);
            */
           


            regionLogic.Update(new Region
            {
                RegionDescription = "Nueva descripcion de region",
                RegionID = 10
            });

            Console.WriteLine("");
            foreach (var region in regionLogic.GetAll())
            {
                Console.WriteLine($"{region.RegionID} - {region.RegionDescription}");
            }

            Console.ReadLine();


        }
    }
}
