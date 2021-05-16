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
        RegionLogic regionLogic = new RegionLogic();

        // GET: Region
        public ActionResult Index()
        {
            List<Region> regiones = regionLogic.GetAll();

            List<RegionView> regionsView = regiones.Select(r => new RegionView
            {
                Id = r.RegionID,
                Description = r.RegionDescription

            }).ToList(); 
            
            return View(regionsView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(RegionView regionView)
        {
            try 
            {
                Region regionEntity = new Region 
                {
                    RegionID = regionLogic.NextAvailableId(),
                    RegionDescription = regionView.Description
                };

                regionLogic.Add(regionEntity);

                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                regionLogic.Delete(new Region { RegionID = id });

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");

            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, RegionView regionView)
        {
            regionLogic.Update(new Region
            {
                RegionID = id,
                RegionDescription = regionView.Description
            });

            return RedirectToAction("Index");
        }
    }
}