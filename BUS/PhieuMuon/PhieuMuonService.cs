using DAL.Acess.PhieuMuon;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.PhieuMuon
{
    public class PhieuMuonService
    {
        private PhieuMuonAcess phieuMuonAcess;
        
        public PhieuMuonService() 
        {
            phieuMuonAcess = new PhieuMuonAcess(); 
        }
        public List<PHIEUMUON> GetAll()
        {
            return phieuMuonAcess.GetAll(); 
        }
        public void AddPhieu(PHIEUMUON phieuMuon)
        {
            if (phieuMuon == null)
            {
                throw new ArgumentNullException("phieuMuon", "Phiếu mượn không thể là null.");
            }            
            if (string.IsNullOrWhiteSpace(phieuMuon.MaPhieuMuon) ||
                string.IsNullOrWhiteSpace(phieuMuon.MaSach) ||
                string.IsNullOrWhiteSpace(phieuMuon.MaNhanVien) ||
                string.IsNullOrWhiteSpace(phieuMuon.MaTheThanhVien))
            {
                throw new Exception("Các trường bắt buộc không được bỏ trống.");
            }

            phieuMuonAcess.AddPhieu(phieuMuon);
        }
        public void UpdatePhieu(PHIEUMUON phieuMuon)
        {
            PhieuMuonAcess phieuMuonAcess = new PhieuMuonAcess();
            phieuMuonAcess.UpdatePhieu(phieuMuon);
        }

        public void DeletePhieu(string maPhieuMuon)
        {
            PhieuMuonAcess phieuMuonAcess = new PhieuMuonAcess();
            phieuMuonAcess.DeletePhieu(maPhieuMuon);
        }

        public PHIEUMUON GetPhieuMuonByMa(string maPhieuMuon)
        {
            PhieuMuonAcess phieuMuonAcess = new PhieuMuonAcess();
            return phieuMuonAcess.GetPhieuMuonByMa(maPhieuMuon);
        }
        
      
    }
}
