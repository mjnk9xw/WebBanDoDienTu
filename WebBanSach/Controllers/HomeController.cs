using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.EF;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        public ActionResult Index()
        {
            List<SanPham> lstSanPhamMoi = db.SanPhams.ToList();
            List<SanPham> lstSanPhamNoiBat = db.SanPhams.ToList();

            ViewBag.ListSanPhamMoi = lstSanPhamMoi ;
            return View(lstSanPhamNoiBat);
        }

        [HttpPost]
        public ActionResult TimKiem(string searchText)
        {
            List<SanPham> lstSanPhamMoi = db.SanPhams.Where(item => item.Ngay == new DateTime(2019, 04, 02)).ToList();
            ViewBag.ListSanPhamMoi = lstSanPhamMoi;

            var listSanPham = db.SanPhams.Where(item => item.TenSanPham.Contains(searchText)).ToList();
            return View("Index", listSanPham);
        }
    }
}