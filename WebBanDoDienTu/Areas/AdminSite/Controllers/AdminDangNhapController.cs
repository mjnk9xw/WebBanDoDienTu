using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.Common;
using WebBanDoDienTu.Models.EF;
using WebBanDoDienTu.Models.Security;

namespace WebBanDoDienTu.Areas.AdminSite.Controllers
{
    public class AdminDangNhapController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        HashPass hp = new HashPass();
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
                string pass_hash = hp.HassPass(user.Password);
                KhachHang khachang = db.KhachHangs.SingleOrDefault(kh => kh.TaiKhoan == user.Username && kh.MatKhau_MaHoa == pass_hash);
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