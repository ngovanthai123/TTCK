using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("PHUKIEN")]
    public partial class Phukien
    {
        public Phukien()
        {
            Binhluans = new HashSet<Binhluan>();
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Khuyenmais = new HashSet<Khuyenmai>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDLoaiPhuKien")]
        public int IdloaiPhuKien { get; set; }
        [Required]
        [StringLength(255)]
        public string TenPhuKien { get; set; }
        [StringLength(255)]
        public string AnhMau { get; set; }
        public int? Gia { get; set; }
        public int? SoLuong { get; set; }
        [Column(TypeName = "text")]
        public string MoTa { get; set; }
        [StringLength(255)]
        public string BaoHanh { get; set; }

        [ForeignKey(nameof(IdloaiPhuKien))]
        [InverseProperty(nameof(Loaiphukien.Phukiens))]
        public virtual Loaiphukien IdloaiPhuKienNavigation { get; set; }
        [InverseProperty(nameof(Binhluan.IdphuKienNavigation))]
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        [InverseProperty(nameof(Chitiethoadon.IdphuKienNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [InverseProperty(nameof(Khuyenmai.IdphuKienNavigation))]
        public virtual ICollection<Khuyenmai> Khuyenmais { get; set; }
    }
}
