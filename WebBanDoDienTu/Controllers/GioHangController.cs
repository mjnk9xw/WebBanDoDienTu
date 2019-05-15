using System;
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

        [HttpPost]
        public ActionResult ThanhToan()
        {
            var kh = Session["USER_SESSION"] as KhachHang;

            var lstItemInCart = Session["CART_SESSION"] as List<CartItem>;
            int tongtien = 0;

            if (lstItemInCart != null)
            {
                List<int> tempList = new List<int>();
                foreach (var item in lstItemInCart)
                {
                    tongtien += ((int)item.Product.Gia - (int)item.Product.GiaKM) * (int)item.Quantity;
                    tempList.Add(item.Product.SanPhamID);
                }

                HoaDon hd = new HoaDon();
                hd.KhachHangID = kh.KhachHangID;
                hd.Time = DateTime.Now;
                hd.TongTien = tongtien;
              
                HoaDon hd_add = db.HoaDons.Add(hd);
                foreach (var item in lstItemInCart) {
                    ChiTietHoaDon ct_hd = new ChiTietHoaDon();
                    ct_hd.HoaDonID = hd_add.HoaDonID;
                    ct_hd.SanPhamID = (int)item.Product.SanPhamID;
                    ct_hd.SoLuong = (int)item.Quantity;
                    ct_hd.ThanhTien = ((int)item.Product.Gia - (int)item.Product.GiaKM) * (int)item.Quantity;
                    db.ChiTietHoaDons.Add(ct_hd);
                }
                db.SaveChanges();

                int[] rmList = tempList.ToArray();
                foreach (var item in rmList)
                {
                    var productRemoved = lstItemInCart.Single(x => x.Product.SanPhamID == item);
                    lstItemInCart.Remove(productRemoved);
                }
            }
            Session["CART_SESSION"] = lstItemInCart;

            return RedirectToAction("Index", "GioHang");
        }

    }
}