using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.EF;
namespace WebBanDoDienTu.Controllers
{
    public class DanhMucController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: DanhMuc
        public ActionResult Index()
        {
            var lstDanhMuc = db.TheLoais.ToList();
            var lstSanPham = db.SanPhams.ToList();

            ViewBag.ListDanhMuc = lstDanhMuc;
            return View(lstSanPham);
        }

        [ChildActionOnly]
        public ActionResult SanPhamLienQuan()
        {
            var listSanPhamLienQuan = db.SanPhams.Where(item => item.Ngay == new DateTime(2019, 04, 03)).Take(5).ToList();
            return PartialView("~/Views/Shared/_SanPhamLienQuan.cshtml", listSanPhamLienQuan);
        }
    }
}