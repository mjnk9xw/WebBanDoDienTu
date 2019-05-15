namespace WebBanDoDienTu.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int KhachHangID { get; set; }

        public string TenKhachHang { get; set; }

        public bool? GioiTinh { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NgaySinh { get; set; }

        public string DiaChi { get; set; }

        public string MatKhau_MaHoa { get; set; }

        [StringLength(50)]
        public string TaiKhoan { get; set; }

        public int? Tien { get; set; }

        public int? Quyen { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
