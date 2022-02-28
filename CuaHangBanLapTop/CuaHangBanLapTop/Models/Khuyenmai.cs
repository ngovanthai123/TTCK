using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("KHUYENMAI")]
    public partial class Khuyenmai
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDSanPam")]
        public int? IdsanPam { get; set; }
        [StringLength(255)]
        public string AnhMauSP { get; set; }
        [StringLength(255)]
        public string TenSP { get; set; }
        [Column("IDPhuKien")]
        public int? IdphuKien { get; set; }
        public int? GiaBan { get; set; }
        public int? GiaKhuyenMai { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayBatDauKhuenMai { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayKetThucKhuyenMai { get; set; }

        [ForeignKey(nameof(IdphuKien))]
        [InverseProperty(nameof(Phukien.Khuyenmais))]
        public virtual Phukien IdphuKienNavigation { get; set; }
        [ForeignKey(nameof(IdsanPam))]
        [InverseProperty(nameof(Sanpham.Khuyenmais))]
        public virtual Sanpham IdsanPamNavigation { get; set; }
    }
}
