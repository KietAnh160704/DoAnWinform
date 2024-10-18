using DAL;
using DAL.Acess;
using DAL.Acess.TacGia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.TacGia
{
    public class TacGiaService
    {
        private readonly TacGiaAcess tacGiaAcess = new TacGiaAcess();
        public List<TACGIA> GetAll()
        {
            Model1 context = new Model1();
            return context.TACGIAs.ToList();
        }
        public void AddTG(TACGIA tacgia)
        {
            tacGiaAcess.AddTG(tacgia);
        }
        public void DeleteTG(string maTacGia)
        {
            using (Model1 context = new Model1())
            {
                var TGtoDelete = context.TACGIAs.FirstOrDefault(s => s.MaTacGia == maTacGia);
                if (TGtoDelete != null)
                {
                    context.TACGIAs.Remove(TGtoDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tac Gia Khong Ton Tai");
                }
            }
        }
        public void UpdateTG(TACGIA tacgia)
        {
            TacGiaAcess tacgiaAcess = new TacGiaAcess();
            tacGiaAcess.UpdateTG(tacgia);
        }
        public List<TACGIA> SearchTG(string searchTG)
        {
            return tacGiaAcess.SearchTG(searchTG);
        }

    }
}
