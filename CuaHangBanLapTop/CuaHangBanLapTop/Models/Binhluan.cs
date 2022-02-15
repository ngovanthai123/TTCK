using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("BINHLUAN")]
    public partial class Binhluan
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDSanPham")]
        public int IdsanPham { get; set; }
        [Column("IDPhuKien")]
        public int IdphuKien { get; set; }
        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayGio { get; set; }
        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        [ForeignKey(nameof(IdphuKien))]
        [InverseProperty(nameof(Phukien.Binhluans))]
        public virtual Phukien IdphuKienNavigation { get; set; }
        [ForeignKey(nameof(IdsanPham))]
        [InverseProperty(nameof(Sanpham.Binhluans))]
        public virtual Sanpham IdsanPhamNavigation { get; set; }
    }
}
