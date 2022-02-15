using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("NOISANXUAT")]
    public partial class Noisanxuat
    {
        public Noisanxuat()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string TenNoiSanXuat { get; set; }

        [InverseProperty(nameof(Sanpham.IdnoiSanXuatNavigation))]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
