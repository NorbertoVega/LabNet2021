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
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al agregar el producto");
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
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("La región que se quiere eliminar no existe");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al eliminar la region");
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
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("La región que se quiere actualizar no existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al actualizar la region");
            }
        }
    }
}
