using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }

        public void Add(Customers customer)
        {
            try 
            { 
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al agregar el customer");
            }
        }

        public void Delete(Customers customer)
        {
            try
            {
                var customerDelete = context.Customers.Find(customer.CustomerID);
                context.Customers.Remove(customerDelete);
                context.SaveChanges();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("El customer que se quiere eliminar no existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al eliminar el customer");
            }
        }

        public void Update(Customers customer)
        {
            try 
            { 
                var customerUpdate = context.Customers.Find(customer.CustomerID);
                customerUpdate.CompanyName = customer.CompanyName;

                context.SaveChanges();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("El customer que se quiere actualizar no existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Hubo un error al actualizar el customer");
            }
        }
    }
}
