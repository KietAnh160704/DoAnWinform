using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Acess.PhieuPhat
{
    public class PhieuPhatAcess
    {
        private Model1 context;
        
        public void AddPhieu(THEPHAT phieuPhat)
        {
            using (var context = new Model1())
            {
                context.THEPHATs.Add(phieuPhat);
                context.SaveChanges();
            }
        }

        public List<THEPHAT> GetAll()
        {
            return context.THEPHATs.ToList();
        }

        public void UpdatePhieu(THEPHAT phieuPhat)
        {

            using (var context = new Model1())
            {

                var existingPhieu = context.THEPHATs.FirstOrDefault(p => p.MaThePhat == phieuPhat.MaThePhat);
                if (existingPhieu != null)
                {
                    existingPhieu.MaPhieuMuon = phieuPhat.MaPhieuMuon;
                    existingPhieu.MaNhanVien = phieuPhat.MaNhanVien;
                    existingPhieu.TienPhat = phieuPhat.TienPhat;
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

        public void DeletePhieu(string maPhieuphat)
        {
            using (var context = new Model1())
            {
                var phieuToDelete = context.THEPHATs.FirstOrDefault(p => p.MaThePhat == maPhieuphat);
                if (phieuToDelete != null)
                {
                    context.THEPHATs.Remove(phieuToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Phiếu mượn không tồn tại.");
                }
            }
        }
    }
}
