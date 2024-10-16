namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            PHIEUMUONs = new HashSet<PHIEUMUON>();
            TACGIAs = new HashSet<TACGIA>();
        }

        [Key]
        [StringLength(5)]
        public string MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(50)]
        public string NhaXuatBan { get; set; }

        public int? NamXuatBan { get; set; }

        public int? SoLuongSachHienCo { get; set; }

        [Required]
        [StringLength(5)]
        public string MaTheLoai { get; set; }

        public int? SoLuongSachMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }

        public virtual THELOAI THELOAI { get; set; }

        public virtual THELOAI THELOAI1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TACGIA> TACGIAs { get; set; }
    }
}
