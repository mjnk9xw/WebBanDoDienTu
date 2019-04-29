using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.EF;

namespace WebBanSach.Controllers
{
    public class DangKiController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: DangKi
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ThemTaiKhoan(KhachHang user)
        {
            try
            {
                user.Quyen = 2;
                db.KhachHangs.Add(user);
                db.SaveChanges();
                
                if (Session["USER_SESSION"] == null)
                {
                    Session.Add("USER_SESSION", user);
                }
                else
                {
                    Session["USER_SESSION"] = user;
                }
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }
    }
}