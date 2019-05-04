﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.Common;
using WebBanDoDienTu.Models.EF;

namespace WebBanDoDienTu.Controllers
{
    public class GioHangController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: GioHang
        public ActionResult Index()
        {
            var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
            return View(lstItemInCart);
        }

        [HttpPost]
        public JsonResult XoaSanPham(int productID)
        {
            try
            {
                var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
                var productRemoved = lstItemInCart.Single(item => item.Product.SanPhamID == productID);
                lstItemInCart.Remove(productRemoved);
                Session["CART_SESSION"] = lstItemInCart;
                return Json(new { status = true });
            }
            catch(Exception ex)
            {
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public JsonResult XoaNhieuSanPham(int[] listProduct)
        {
            try
            {
                var listItemInCart = Session["CART_SESSION"] as List<CartItem>;
                foreach(int productID in listProduct)
                {
                    var productRemoved = listItemInCart.Single(item => item.Product.SanPhamID == productID);
                    listItemInCart.Remove(productRemoved);
                }
                Session["CART_SESSION"] = listItemInCart;
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
    }
}