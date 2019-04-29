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
        QuanLyBanSachDbContext db = new QuanLyBanSachDbContext();
        public ActionResult Index()
        {
            List<Sach> lstSachMoi = db.Saches.Where(item => item.Ngaycapnhat == new DateTime(2019, 04, 02)).ToList();
            List<Sach> lstSachNoiBat = db.Saches.ToList();

            ViewBag.ListSachMoi = lstSachMoi;
            return View(lstSachNoiBat);
        }

        [HttpPost]
        public ActionResult TimKiem(string searchText)
        {
            List<Sach> lstSachMoi = db.Saches.Where(item => item.Ngaycapnhat == new DateTime(2019, 04, 02)).ToList();
            ViewBag.ListSachMoi = lstSachMoi;

            var listSach = db.Saches.Where(item => item.Tensach.Contains(searchText)).ToList();
            return View("Index", listSach);
        }
    }
}