using DAL;
using DAL.Acess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SachService
    {
        private readonly SachAcess sachAcess = new SachAcess();
        public List<SACH> GetAll()
        {
            Model1 context = new Model1();
            return context.SACHes.ToList();
        }
        public void AddBook(SACH sach)
        {
            sachAcess.AddSACH(sach);
        }
        public void DeleteBook(string maSach)
        {
            using (Model1 context = new Model1())
            {
                var sachToDelete = context.SACHes.FirstOrDefault(s => s.MaSach == maSach);
                if (sachToDelete != null)
                {
                    context.SACHes.Remove(sachToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Sách không tồn tại.");
                }
            }
        }
        public void UpdateBook(SACH sach)
        {
            SachAcess sachAcess = new SachAcess();
            sachAcess.UpdateBook(sach); 
        }
        public List<SACH> SearchBooks(string searchTerm)
        {
            return sachAcess.SearchBooks(searchTerm);
        }

        public List<SACH> SearchBooksUser(string searchTerm, string maTheLoai)
        {
            return sachAcess.SearchBooksUser(searchTerm, maTheLoai);
        }
    }
}
