using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Acess.TacGia
{
    public class TacGiaAcess
    {
        private Model1 context = new Model1();
        public void AddTG (TACGIA tacGia)
        {
            using (var context = new Model1())
            {
                context.TACGIAs.Add(tacGia);
                context.SaveChanges();
            }
        }
        public List<TACGIA> GetAll()
        {
            return context.TACGIAs.ToList();
        }
        public void UpdateTG(TACGIA tacGia)
        {
            using (var context = new Model1())
            {
                var existingSach = context.TACGIAs.FirstOrDefault(s => s.MaTacGia == tacGia.MaTacGia);
                if (existingSach != null)
                {
                    existingSach.Ten = tacGia.Ten;
                    existingSach.HoLot = tacGia.HoLot;
                    existingSach.TieuSuTacGia = tacGia.TieuSuTacGia;
                    
                    context.SaveChanges();
                }
            }
        }
        public void DeleteTG(string maTacGia)
        {
            using (var context = new Model1())
            {
                var TGDelete = context.TACGIAs.FirstOrDefault(s => s.MaTacGia == maTacGia);
                if (TGDelete != null)
                {
                    context.TACGIAs.Remove(TGDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Sách không tồn tại.");
                }
            }
        }
        public List<TACGIA> SearchTG(string searchTG)
        {
            return context.TACGIAs
                .Where(s => s.Ten.Contains(searchTG) || s.HoLot.Contains(searchTG))
                .ToList();
        }
    }
}
