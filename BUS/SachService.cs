using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SachService
    {
        public List<SACH> GetAll()
        {
            Model1 context = new Model1();
            return context.SACHes.ToList();
        }
        public void AddStudent(SACH sach)
        {
            Model1 context = new Model1();
            context.SACHes.Add(sach);
            context.SaveChanges();
        }
    }
}
