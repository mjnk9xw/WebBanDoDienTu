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
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: DanhMuc
        public ActionResult Index()
        {
            var lstDanhMuc = db.TheLoais.ToList();
            var lstSach = db.SanPhams.ToList();

            ViewBag.ListDanhMuc = lstDanhMuc;
            return View(lstSach);
        }

        [ChildActionOnly]
        public ActionResult SachLienQuan()
        {
            var listSachLienQuan = db.SanPhams.ToList();
            return PartialView("~/Views/Shared/_SanPhamLienQuan.cshtml", listSachLienQuan);
        }
    }
}