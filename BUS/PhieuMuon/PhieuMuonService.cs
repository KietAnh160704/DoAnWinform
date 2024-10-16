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
