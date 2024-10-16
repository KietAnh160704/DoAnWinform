namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheThanhVien")]
    public partial class TheThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheThanhVien()
        {
            PHIEUMUONs = new HashSet<PHIEUMUON>();
        }

        [Key]
        [StringLength(10)]
        public string MaTheThanhVien { get; set; }

        [Required]
        [StringLength(5)]
        public string MaThanhVien { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }

        public virtual THANHVIEN THANHVIEN { get; set; }
    }
}
