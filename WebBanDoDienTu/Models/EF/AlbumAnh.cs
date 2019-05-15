namespace WebBanDoDienTu.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlbumAnh")]
    public partial class AlbumAnh
    {
        [Key]
        public int AnhID { get; set; }

        public int? SanPhamID { get; set; }

        [Required]
        public string Link { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
