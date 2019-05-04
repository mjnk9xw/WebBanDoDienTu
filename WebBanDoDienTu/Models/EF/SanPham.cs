//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanDoDienTu.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.AlbumAnhs = new HashSet<AlbumAnh>();
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public int SanPhamID { get; set; }
        public Nullable<int> TheLoaiID { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<int> GiaKM { get; set; }
        public Nullable<int> Gia { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string AnhDaiDien { get; set; }
        public Nullable<int> NSXID { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlbumAnh> AlbumAnhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual NSX NSX { get; set; }
        public virtual TheLoai TheLoai { get; set; }
    }
}
