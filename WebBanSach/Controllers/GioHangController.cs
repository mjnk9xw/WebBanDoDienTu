using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.Common;
using WebBanSach.Models.EF;

namespace WebBanSach.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanSachDbContext db = new QuanLyBanSachDbContext();
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
                var productRemoved = lstItemInCart.Single(item => item.Product.Masach == productID);
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
                    var productRemoved = listItemInCart.Single(item => item.Product.Masach == productID);
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