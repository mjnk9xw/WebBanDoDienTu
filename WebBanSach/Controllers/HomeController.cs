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
            List<SanPham> lstSachMoi = db.SanPhams.Where(item => item.Ngay == new DateTime(2019, 04, 02)).ToList();
            List<SanPham> lstSachNoiBat = db.SanPhams.ToList();

            ViewBag.ListSachMoi = lstSachMoi;
            return View(lstSachNoiBat);
        }

        [HttpPost]
        public ActionResult TimKiem(string searchText)
        {
            List<SanPham> lstSachMoi = db.SanPhams.Where(item => item.Ngay == new DateTime(2019, 04, 02)).ToList();
            ViewBag.ListSachMoi = lstSachMoi;

            var listSach = db.SanPhams.Where(item => item.TenSanPham.Contains(searchText)).ToList();
            return View("Index", listSach);
        }
    }
}