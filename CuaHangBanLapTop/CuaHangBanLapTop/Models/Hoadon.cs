using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadons = new HashSet<Chitiethoadon>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDKhachHang")]
        public int? IdkhachHang { get; set; }
        [Column("IDTinhTrang")]
        public int? IdtinhTrang { get; set; }
        [Column("IDNhanVien")]
        public int? IdnhanVien { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }
        public int? TongGia { get; set; }
        [StringLength(255)]
        public string NoiNhan { get; set; }
        [Column(TypeName = "text")]
        public string GhiChu { get; set; }

        [ForeignKey(nameof(IdkhachHang))]
        [InverseProperty(nameof(Khachhang.Hoadons))]
        public virtual Khachhang IdkhachHangNavigation { get; set; }
        [ForeignKey(nameof(IdnhanVien))]
        [InverseProperty(nameof(Nhanvien.Hoadons))]
        public virtual Nhanvien IdnhanVienNavigation { get; set; }
        [ForeignKey(nameof(IdtinhTrang))]
        [InverseProperty(nameof(Tinhtrang.Hoadons))]
        public virtual Tinhtrang IdtinhTrangNavigation { get; set; }
        [InverseProperty(nameof(Chitiethoadon.IdhoaDonNavigation))]
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
    }
}
