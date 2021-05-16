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
            try
            {
                return regionLogic.GetAll();
            }
            catch
            {
                return null;
            }
        }

        // GET api/values/5
        public Region Get(int id)
        {
            try
            {
                return regionLogic.GetAll().Where(r => r.RegionID == id).ToList().First();
            }
            catch
            {
                return null;
            }
        }

        // POST api/values
        public void Post([FromBody] Region region)
        {
            try
            {
                region.RegionID = regionLogic.NextAvailableId();
                regionLogic.Add(region);
            }
            catch { }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Region region)
        {
            try
            {
                regionLogic.Update(new Region
                {
                    RegionID = id,
                    RegionDescription = region.RegionDescription
                });
            }
            catch { }

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            try
            {
                regionLogic.Delete(new Region { RegionID = id });
            }
            catch { }
        }
    }
}
