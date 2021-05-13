using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ProductsLogic
    {
        private readonly NorthwindContext context;

        public ProductsLogic()
        {
            context = new NorthwindContext();
        }

        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }
    }
}
