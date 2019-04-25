namespace WebBanSach.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khachhang")]
    public partial class Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khachhang()
        {
            Giohangkhs = new HashSet<Giohangkh>();
        }

        [Key]
        public int Makh { get; set; }

        [StringLength(100)]
        public string Hotenkh { get; set; }

        [StringLength(100)]
        public string Diachikh { get; set; }

        [StringLength(20)]
        public string Dienthoaikh { get; set; }

        [StringLength(50)]
        public string Tendn { get; set; }

        [StringLength(100)]
        public string Matkhau { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Ngaysinh { get; set; }

        public bool? Gioitinh { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giohangkh> Giohangkhs { get; set; }
    }
}
