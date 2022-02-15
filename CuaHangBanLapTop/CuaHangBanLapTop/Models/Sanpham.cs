using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("SANPHAM")]
    public partial class Sanpham
    {
        public Sanpham()
        {
            Binhluans = new HashSet<Binhluan>();
            Chitiethoadons = new HashSet<Chitiethoadon>();
            Khuyenmais = new HashSet<Khuyenmai>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDNoiSanXuat")]
        public int IdnoiSanXuat { get; set; }
        [Column("IDDongSanPham")]
        public int IddongSanPham { get; set; }
        [Required]
        [StringLength(255)]
        public string TenSanPham { get; set; }
        [StringLength(255)]
        public string AnhSanPham { get; set; }
        public int GiaSanPham { get; set; }
        public int? SoLuong { get; set; }
        [Column(TypeName = "text")]
        public string MoTa { get; set; }
        [StringLength(255)]
        public string BaoHanh { get; set; }

        [ForeignKey(nameof(IddongSanPham))]
        [InverseProperty(nameof(Dongsanpham.Sanphams))]
        public virtual Dongsanpham IddongSanPhamNavigation { get; set; }
        [ForeignKey(nameof(IdnoiSanXuat))]
        [InverseProperty(nameof(Noisanxuat.Sanphams))]
        public virtual Noisanxuat IdnoiSanXuatNavigation { get; set; }
        [InverseProperty(nameof(Binhluan.IdsanPhamNavigation))]
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        [InverseProperty(nameof(Chitiethoadon.IdsanPhamNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [InverseProperty(nameof(Khuyenmai.IdsanPamNavigation))]
        public virtual ICollection<Khuyenmai> Khuyenmais { get; set; }
    }
}
