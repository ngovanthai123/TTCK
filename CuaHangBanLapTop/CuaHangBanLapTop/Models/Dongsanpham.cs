using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("DONGSANPHAM")]
    public partial class Dongsanpham
    {
        public Dongsanpham()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDDanhMuc")]
        public int IddanhMuc { get; set; }
        [Required]
        [StringLength(255)]
        public string TenSanPham { get; set; }

        [ForeignKey(nameof(IddanhMuc))]
        [InverseProperty(nameof(Danhmucsanpham.Dongsanphams))]
        public virtual Danhmucsanpham IddanhMucNavigation { get; set; }
        [InverseProperty(nameof(Sanpham.IddongSanPhamNavigation))]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
