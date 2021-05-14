using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T entitity);
        void Delete(T entity);

        void Update(T entity);
    }
}
