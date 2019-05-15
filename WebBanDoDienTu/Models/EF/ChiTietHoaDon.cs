namespace WebBanDoDienTu.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        public int ChiTietHoaDonID { get; set; }

        public int? HoaDonID { get; set; }

        public int? SanPhamID { get; set; }

        public int? SoLuong { get; set; }

        public int? ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
