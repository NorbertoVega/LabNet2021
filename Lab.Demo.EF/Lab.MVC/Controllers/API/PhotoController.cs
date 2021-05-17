using Lab.EF.Data.API;
using Lab.EF.Entities.API;
using Lab.MVC.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers.API
{
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            try
            {
                FetchAPIData fetchData = new FetchAPIData();

                List<Photo> photos = fetchData.Fetch();

                List<PhotoView> photosView = photos.Select(p => new PhotoView
                {
                    Id = p.id,
                    CameraName = p.camera.name,
                    ImgSource = p.img_src,
                    EarthDate = p.earth_date,
                    RoverName = p.rover.name
                }).ToList();

                return View(photosView);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { message = $"Descripción de error: {e.Message}" });

            }

        }
    }
}