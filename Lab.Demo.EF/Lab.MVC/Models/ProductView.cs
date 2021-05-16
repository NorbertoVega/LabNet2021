using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class ProductView
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal? UnitPrice { set; get; }
        public short? UnitsInStock { get; set; }

    }
}