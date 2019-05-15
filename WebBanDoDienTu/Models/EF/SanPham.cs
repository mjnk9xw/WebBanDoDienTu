namespace WebBanDoDienTu.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            AlbumAnhs = new HashSet<AlbumAnh>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int SanPhamID { get; set; }

        public int? TheLoaiID { get; set; }

        public string TenSanPham { get; set; }

        public int? GiaKM { get; set; }

        public int? Gia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(100)]
        public string AnhDaiDien { get; set; }

        public int? NSXID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumAnh> AlbumAnhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual NSX NSX { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
