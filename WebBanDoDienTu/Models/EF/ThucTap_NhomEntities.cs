namespace WebBanDoDienTu.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ThucTap_NhomEntities : DbContext
    {
        public ThucTap_NhomEntities()
            : base("name=ThucTap_NhomEntities")
        {
        }

        public virtual DbSet<AlbumAnh> AlbumAnhs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<NSX> NSXes { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau_MaHoa)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.Key)
                .IsFixedLength();
        }
    }
}
