using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class RegionLogic: BaseLogic, IABMLogic<Region>
    {
        public List<Region> GetAll()
        {
            return context.Region.ToList();
        }

        public void Add(Region newRegion)
        {
            try
            {
                context.Region.Add(newRegion);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Region region)
        {
            try
            {
                var regionAEliminar = context.Region.Find(region.RegionID);

                context.Region.Remove(regionAEliminar);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        
        }

        public void Update(Region region)
        {
            try
            {
                var regionUpdate = context.Region.Find(region.RegionID);

                regionUpdate.RegionDescription = region.RegionDescription;
                context.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        public int NextAvailableId() 
        {
            try
            {
                var nextId = context.Region.Max(r => r.RegionID);

                return nextId + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
