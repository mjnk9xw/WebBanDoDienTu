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
    
    public partial class AlbumAnh
    {
        public int AnhID { get; set; }
        public Nullable<int> SanPhamID { get; set; }
        public string Link { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}
