using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanSach.Models.EF;

namespace WebBanSach.Models.Common
{
    [Serializable]
    public class CartItem
    {
        public Sach Product { get; set; }
        public int Quantity { get; set; }
    }
}