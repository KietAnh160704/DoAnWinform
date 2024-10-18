using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DAL.Acess.PhieuMuon
{
    public class PhieuMuonAcess
    {
        private Model1 context ;
        public PhieuMuonAcess()
        {
            context = new Model1();
        }

        public void AddPhieu(PHIEUMUON phieuMuon)
        {
            using (var context = new Model1())
            {
                context.PHIEUMUONs.Add(phieuMuon);
                context.SaveChanges();
            }
        }

        public List<PHIEUMUON> GetAll()
        {
            return context.PHIEUMUONs.ToList();
        }

        public void UpdatePhieu(PHIEUMUON phieuMuon)
        {

            using (var context = new Model1())
            {

                var existingPhieu = context.PHIEUMUONs.FirstOrDefault(p => p.MaPhieuMuon == phieuMuon.MaPhieuMuon);
                if (existingPhieu != null)
                {
                    existingPhieu.MaSach = phieuMuon.MaSach;
                    existingPhieu.NgayMuon = phieuMuon.NgayMuon;
                    existingPhieu.NgayTra = phieuMuon.NgayTra;
                    existingPhieu.MaNhanVien = phieuMuon.MaNhanVien;
                    existingPhieu.MaTheThanhVien = phieuMuon.MaTheThanhVien;
                    existingPhieu.TrangThai = phieuMuon.TrangThai;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật phiếu mượn: " + ex.Message);
                    }
                }
                else
                {
                    throw new Exception("Phiếu mượn không tồn tại.");
                }
            }
        }

        public void DeletePhieu(string maPhieuMuon)
        {
            using (var context = new Model1())
            {
                var phieuToDelete = context.PHIEUMUONs.FirstOrDefault(p => p.MaPhieuMuon == maPhieuMuon);
                if (phieuToDelete != null)
                {
                    context.PHIEUMUONs.Remove(phieuToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Phiếu mượn không tồn tại.");
                }
            }
        }
        public List<PHIEUMUON> GetPhieuMuonsByKeyword(string keyword)
        {
            return context.PHIEUMUONs.Where(pm => pm.MaPhieuMuon.Contains(keyword)).ToList();
        }
        public PHIEUMUON GetPhieuMuonByMa(string maPhieuMuon)
        {
            return context.PHIEUMUONs.Include(pm => pm.SACH)
                .FirstOrDefault(pm => pm.MaPhieuMuon == maPhieuMuon);
        }        
       
    }
}

