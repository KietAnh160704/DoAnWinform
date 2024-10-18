using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Acess
{
    public class SachAcess
    {
        private Model1 context = new Model1();

        public void AddSACH(SACH sach)
        {
            using (var context = new Model1())
            {
                context.SACHes.Add(sach);
                context.SaveChanges();
            }
        }
        public List<SACH> GetAll()
        {
            return context.SACHes.ToList(); 
        }
        public void UpdateBook(SACH sach)
        {
            using (var context = new Model1())
            {
                var existingSach = context.SACHes.FirstOrDefault(s => s.MaSach == sach.MaSach);
                if (existingSach != null)
                {
                    existingSach.TenSach = sach.TenSach;
                    existingSach.NhaXuatBan = sach.NhaXuatBan;
                    existingSach.NamXuatBan = sach.NamXuatBan;
                    existingSach.SoLuongSachHienCo = sach.SoLuongSachHienCo;
                    existingSach.MaTheLoai = sach.MaTheLoai;

                    context.SaveChanges();
                }
            }
        }
        public void DeleteBook(string maSach)
        {
            using (var context = new Model1())
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
        public List<SACH> SearchBooks(string searchTerm)
        {
            return context.SACHes
                .Where(s => s.TenSach.Contains(searchTerm) || s.NhaXuatBan.Contains(searchTerm))
                .ToList();
        }
    }
}

