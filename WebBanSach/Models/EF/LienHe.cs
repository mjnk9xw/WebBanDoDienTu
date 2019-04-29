using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanSach.Models.EF
{
    [Table("LienHe")]
    public partial class LienHe
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(13)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(int.MaxValue)]
        public string NoiDung { get; set; }
    }
}