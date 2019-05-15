﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanDoDienTu.Models.EF;

namespace WebBanDoDienTu.Models.Common
{
    [Serializable]
    public class CartItem
    {
        public SanPham Product { get; set; }
        public int Quantity { get; set; }
    }
}