namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUON")]
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUON()
        {
            THEPHATs = new HashSet<THEPHAT>();
        }

        [Key]
        [StringLength(5)]
        public string MaPhieuMuon { get; set; }

        public DateTime? NgayMuon { get; set; }

        public DateTime? NgayTra { get; set; }

        [Required]
        [StringLength(5)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTheThanhVien { get; set; }

        public bool? TrangThai { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual TheThanhVien TheThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEPHAT> THEPHATs { get; set; }
    }
}
