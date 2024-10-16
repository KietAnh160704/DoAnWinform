namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THEPHAT")]
    public partial class THEPHAT
    {
        [Key]
        [StringLength(5)]
        public string MaThePhat { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhieuMuon { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        [Column(TypeName = "money")]
        public decimal? TienPhat { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }
    }
}
