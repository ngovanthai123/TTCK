using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("LOAIPHUKIEN")]
    public partial class Loaiphukien
    {
        public Loaiphukien()
        {
            Phukiens = new HashSet<Phukien>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDDanhMuc")]
        public int IddanhMuc { get; set; }
        [Required]
        [StringLength(255)]
        public string TenPhuKien { get; set; }

        [ForeignKey(nameof(IddanhMuc))]
        [InverseProperty(nameof(Danhmucsanpham.Loaiphukiens))]
        public virtual Danhmucsanpham IddanhMucNavigation { get; set; }
        [InverseProperty(nameof(Phukien.IdloaiPhuKienNavigation))]
        public virtual ICollection<Phukien> Phukiens { get; set; }
    }
}
