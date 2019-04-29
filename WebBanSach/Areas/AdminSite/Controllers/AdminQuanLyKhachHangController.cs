using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.Common;
using WebBanSach.Models.EF;
using PagedList;

namespace WebBanSach.Areas.AdminSite.Controllers
{
    public class AdminQuanLyKhachHangController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: AdminSite/AdminQuanLyKhachHang
        [HasCredential(Quyen = 1)]
        public ActionResult TatCaKhachHang()
        {
            var TatCaKhachHang = db.KhachHangs
                                 .OrderByDescending(kh => kh.TenKhachHang)
                                 .ToList();
            return View(TatCaKhachHang);
        }
        public ActionResult ThemKhachHang()
        {
            return View();
        }
        public ActionResult SuaKhachHang()
        {
            return View();
        }
    }
}