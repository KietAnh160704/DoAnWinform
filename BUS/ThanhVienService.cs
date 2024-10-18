using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThanhVienService

    {
        public List<THANHVIEN> GetAll()
        {
            Model1 context = new Model1();
            return context.THANHVIENs.ToList();
        }
        public void AddThanhVien(THANHVIEN tv)
        {
            Model1 context = new Model1();
            context.THANHVIENs.Add(tv);
            context.SaveChanges();
        }
        public void UpdateThanhVien(THANHVIEN updatedMember, string oldMaThanhVien)
        {
            using (var context = new Model1())
            {
                
                var existingMember = context.THANHVIENs.FirstOrDefault(tv => tv.MaThanhVien == oldMaThanhVien);

                if (existingMember != null)
                {
                    
                    existingMember.MaThanhVien = updatedMember.MaThanhVien;
                    existingMember.TenThanhVien = updatedMember.TenThanhVien;
                    existingMember.DiaChi = updatedMember.DiaChi;
                    existingMember.SoDienThoai = updatedMember.SoDienThoai;
                    existingMember.Email = updatedMember.Email;
                    existingMember.NgayDangKyThanhVien = updatedMember.NgayDangKyThanhVien;                    
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy thành viên với mã: " + oldMaThanhVien);
                }
            }
        }

        public void DeleteThanhVien(string maThanhVien)
        {
            using (var context = new Model1())
            {
                var thanhVienToDelete = context.THANHVIENs.FirstOrDefault(tv => tv.MaThanhVien == maThanhVien);

                if (thanhVienToDelete != null)
                {
                    context.THANHVIENs.Remove(thanhVienToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Không tìm thấy thành viên với mã: " + maThanhVien);
                }
            }
        }

        public List<THANHVIEN> SearchThanhVien(string searchTerm)
        {
            using (var context = new Model1())
            {
                
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return context.THANHVIENs.ToList(); 
                }

                
                return context.THANHVIENs
                              .Where(tv => tv.TenThanhVien.Contains(searchTerm))
                              .ToList();
            }
        }


    }
}
