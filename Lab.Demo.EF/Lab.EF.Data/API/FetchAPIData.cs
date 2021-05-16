using Lab.EF.Entities.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Data.API
{
    public class FetchAPIData
    {
        const string MARS_ROVERS_PHOTOS_URL = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&page=5&api_key=DEMO_KEY";
        public List<Photo> Fetch()
        {
            try
            {
                var webClient = new WebClient();

                var datos = webClient.DownloadString(MARS_ROVERS_PHOTOS_URL);

                var photoList = JsonConvert.DeserializeObject<Root>(datos);

                return photoList.photos;
            }
            catch
            {
                throw;
            }
          
        }
    }
}
