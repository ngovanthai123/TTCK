using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("TINHTRANG")]
    public partial class Tinhtrang
    {
        public Tinhtrang()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TinhTrang")]
        [Display(Name ="Tinh trang")]
        public int? TinhTrang1 { get; set; }

        [InverseProperty(nameof(Hoadon.IdtinhTrangNavigation))]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
