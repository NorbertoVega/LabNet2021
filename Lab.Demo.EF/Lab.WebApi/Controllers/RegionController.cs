using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.WebApi.Controllers
{
    public class RegionController : ApiController
    {
        RegionLogic regionLogic = new RegionLogic(); 

        // GET api/values
        public IEnumerable<Region> Get()
        {
             return regionLogic.GetAll();
      
        }

        // GET api/values/5
        public Region Get(int id)
        {
            return regionLogic.GetAll().Where(r => r.RegionID == id).ToList().First();

        }

        // POST api/values
        public void Post([FromBody] Region region)
        {
            region.RegionID = regionLogic.NextAvailableId();
            regionLogic.Add(region);
           
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Region region)
        {           
            regionLogic.Update(new Region
            {
                RegionID = id,
                RegionDescription = region.RegionDescription
            });
          
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            regionLogic.Delete(new Region { RegionID = id });
            
           
        }
    }
}
