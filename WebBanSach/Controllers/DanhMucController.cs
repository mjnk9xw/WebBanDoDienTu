using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.EF;
namespace WebBanSach.Controllers
{
    public class DanhMucController : Controller
    {
        QuanLyBanSachDbContext db = new QuanLyBanSachDbContext();
        // GET: DanhMuc
        public ActionResult Index()
        {
            var lstDanhMuc = db.Chudes.ToList();
            var lstSach = db.Saches.ToList();

            ViewBag.ListDanhMuc = lstDanhMuc;
            return View(lstSach);
        }

        [ChildActionOnly]
        public ActionResult SachLienQuan()
        {
            var listSachLienQuan = db.Saches.Where(item => item.Ngaycapnhat == new DateTime(2019, 04, 03)).Take(5).ToList();
            return PartialView("~/Views/Shared/_SanPhamLienQuan.cshtml", listSachLienQuan);
        }
    }
}