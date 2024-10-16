using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUMUON> PHIEUMUONs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }
        public virtual DbSet<THEPHAT> THEPHATs { get; set; }
        public virtual DbSet<TheThanhVien> TheThanhViens { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.THEPHATs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.TheThanhViens)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MaPhieuMuon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .Property(e => e.MaTheThanhVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.THEPHATs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.TACGIAs)
                .WithMany(e => e.SACHes)
                .Map(m => m.ToTable("SACH_TACGIA").MapLeftKey("MaSach").MapRightKey("MaTacGia"));

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.MaTacGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.TieuSuTacGia)
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.MaThanhVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THANHVIEN>()
                .HasMany(e => e.TheThanhViens)
                .WithRequired(e => e.THANHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.THELOAI)
                .HasForeignKey(e => e.MaTheLoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes1)
                .WithRequired(e => e.THELOAI1)
                .HasForeignKey(e => e.MaTheLoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MaThePhat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MaPhieuMuon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEPHAT>()
                .Property(e => e.TienPhat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TheThanhVien>()
                .Property(e => e.MaTheThanhVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheThanhVien>()
                .Property(e => e.MaThanhVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheThanhVien>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheThanhVien>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.TheThanhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.UserId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
