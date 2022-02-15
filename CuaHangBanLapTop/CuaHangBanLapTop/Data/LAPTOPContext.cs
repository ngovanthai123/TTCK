using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CuaHangBanLapTop.Models;

#nullable disable

namespace CuaHangBanLapTop.Data
{
    public partial class LAPTOPContext : DbContext
    {
        public LAPTOPContext()
        {
        }

        public LAPTOPContext(DbContextOptions<LAPTOPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Binhluan> Binhluans { get; set; }
        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Danhmucsanpham> Danhmucsanphams { get; set; }
        public virtual DbSet<Dongsanpham> Dongsanphams { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }
        public virtual DbSet<Loaiphukien> Loaiphukiens { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Noisanxuat> Noisanxuats { get; set; }
        public virtual DbSet<Phukien> Phukiens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Tinhtrang> Tinhtrangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-R5QB9QIO;Database=LAPTOP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Binhluan>(entity =>
            {
                entity.HasOne(d => d.IdphuKienNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.IdphuKien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BINHLUAN__IDPhuK__34C8D9D1");

                entity.HasOne(d => d.IdsanPhamNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.IdsanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BINHLUAN__IDSanP__33D4B598");
            });

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.IdhoaDon)
                    .HasConstraintName("FK__CHITIETHO__IDHoa__2D27B809");

                entity.HasOne(d => d.IdphuKienNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.IdphuKien)
                    .HasConstraintName("FK__CHITIETHO__IDPhu__2E1BDC42");

                entity.HasOne(d => d.IdsanPhamNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.IdsanPham)
                    .HasConstraintName("FK__CHITIETHO__IDSan__2C3393D0");
            });

            modelBuilder.Entity<Dongsanpham>(entity =>
            {
                entity.HasOne(d => d.IddanhMucNavigation)
                    .WithMany(p => p.Dongsanphams)
                    .HasForeignKey(d => d.IddanhMuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DONGSANPH__IDDan__30F848ED");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasOne(d => d.IdkhachHangNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.IdkhachHang)
                    .HasConstraintName("FK__HOADON__IDKhachH__29572725");

                entity.HasOne(d => d.IdnhanVienNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.IdnhanVien)
                    .HasConstraintName("FK__HOADON__IDNhanVi__2A4B4B5E");

                entity.HasOne(d => d.IdtinhTrangNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.IdtinhTrang)
                    .HasConstraintName("FK__HOADON__IDTinhTr__2B3F6F97");
            });

            modelBuilder.Entity<Khuyenmai>(entity =>
            {
                entity.HasOne(d => d.IdphuKienNavigation)
                    .WithMany(p => p.Khuyenmais)
                    .HasForeignKey(d => d.IdphuKien)
                    .HasConstraintName("FK__KHUYENMAI__IDPhu__300424B4");

                entity.HasOne(d => d.IdsanPamNavigation)
                    .WithMany(p => p.Khuyenmais)
                    .HasForeignKey(d => d.IdsanPam)
                    .HasConstraintName("FK__KHUYENMAI__IDSan__2F10007B");
            });

            modelBuilder.Entity<Loaiphukien>(entity =>
            {
                entity.HasOne(d => d.IddanhMucNavigation)
                    .WithMany(p => p.Loaiphukiens)
                    .HasForeignKey(d => d.IddanhMuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOAIPHUKI__IDDan__31EC6D26");
            });

            modelBuilder.Entity<Phukien>(entity =>
            {
                entity.HasOne(d => d.IdloaiPhuKienNavigation)
                    .WithMany(p => p.Phukiens)
                    .HasForeignKey(d => d.IdloaiPhuKien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHUKIEN__IDLoaiP__32E0915F");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasOne(d => d.IddongSanPhamNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IddongSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SANPHAM__IDDongS__286302EC");

                entity.HasOne(d => d.IdnoiSanXuatNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.IdnoiSanXuat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SANPHAM__IDNoiSa__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
