using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Acess.PhieuPhat;
using DAL.Acess.PhieuMuon;

namespace BUS.PhieuPhatService
{
    public class PhieuPhatService
    {
        PhieuPhatAcess phieuPhatAcess;
        public PhieuPhatService()
        {
            phieuPhatAcess = new PhieuPhatAcess();
        }
        public List<THEPHAT> GetAll()
        {
            return phieuPhatAcess.GetAll();
        }
        public void AddPhieu(THEPHAT phieuPhat)
        {
            if (phieuPhat == null)
            {
                throw new ArgumentNullException("phieuMuon", "Phiếu mượn không thể là null.");
            }
            if (string.IsNullOrWhiteSpace(phieuPhat.MaThePhat) ||
                string.IsNullOrWhiteSpace(phieuPhat.MaPhieuMuon) ||
                string.IsNullOrWhiteSpace(phieuPhat.MaNhanVien) ||
                phieuPhat.TienPhat <= 0)
            {
                throw new Exception("Các trường bắt buộc không được bỏ trống.");
            }

            phieuPhatAcess.AddPhieu(phieuPhat);
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

