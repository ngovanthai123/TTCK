using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CuaHangBanLapTop.Models
{
    [Table("DANHMUCSANPHAM")]
    public partial class Danhmucsanpham
    {
        public Danhmucsanpham()
        {
            Dongsanphams = new HashSet<Dongsanpham>();
            Loaiphukiens = new HashSet<Loaiphukien>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string TenDanhMuc { get; set; }

        [InverseProperty(nameof(Dongsanpham.IddanhMucNavigation))]
        public virtual ICollection<Dongsanpham> Dongsanphams { get; set; }
        [InverseProperty(nameof(Loaiphukien.IddanhMucNavigation))]
        public virtual ICollection<Loaiphukien> Loaiphukiens { get; set; }
    }
}
