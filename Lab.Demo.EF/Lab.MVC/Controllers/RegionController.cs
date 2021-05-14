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
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            var regionLogic = new RegionLogic();
            List<Region> regiones = regionLogic.GetAll();

            List<RegionView> regionsView = regiones.Select(r => new RegionView
            {
                Id = r.RegionID,
                Description = r.RegionDescription

            }).ToList(); 
            
            return View(regionsView);
        }
    }
}