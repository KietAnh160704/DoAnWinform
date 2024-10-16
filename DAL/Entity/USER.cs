namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [StringLength(5)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        [StringLength(5)]
        public string MaNhanVien { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
