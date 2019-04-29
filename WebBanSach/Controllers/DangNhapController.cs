using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.Common;
using WebBanSach.Models.EF;

namespace WebBanSach.Controllers
{
    public class DangNhapController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: DangNhap
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                KhachHang khachHang = db.KhachHangs.SingleOrDefault(item => item.TaiKhoan == user.Username && item.MatKhau_MaHoa == user.Password);
                if (khachHang == null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng. Xin kiểm tra lại!");
                } else
                {
                    Session.Add("USER_SESSION", khachHang);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }

        public ActionResult DangXuat()
        {
            Session.Remove("USER_SESSION");
            return RedirectToAction("Index", "Home");
        }
    }
}