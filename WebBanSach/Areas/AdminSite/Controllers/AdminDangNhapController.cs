using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.Common;
using WebBanSach.Models.EF;

namespace WebBanSach.Areas.AdminSite.Controllers
{
    public class AdminDangNhapController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: AdminSite/AdminDangNhap
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                KhachHang khachang = db.KhachHangs.SingleOrDefault(kh => kh.TaiKhoan == user.Username && kh.MatKhau_MaHoa == user.Password);
                if (khachang != null && khachang.Quyen == 1)
                {
                    Session.Add("ADMIN_SESSION", khachang);
                    return RedirectToAction("TatCaSanPham", "AdminQuanLySanPham");
                }
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Remove("ADMIN_SESSION");
            return RedirectToAction("Index");
        }
    }
}