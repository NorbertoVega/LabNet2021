using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models.API
{
    public class PhotoView
    {
        public int Id { get; set; }
        public string CameraName { get; set; }
        public string ImgSource { get; set; }
        public string EarthDate { get; set; }
        public string RoverName { get; set; }
    }
}