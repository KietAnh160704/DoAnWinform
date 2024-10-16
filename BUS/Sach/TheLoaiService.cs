using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TheLoaiService
    {
        public List<THELOAI> GetAll()
        {
            Model1 context = new Model1();
            return context.THELOAIs.ToList();
        }
    }
}
