using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.EF;
using WebBanDoDienTu.Models.Security;

namespace WebBanDoDienTu.Controllers
{
    public class DangKiController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        HashPass hp = new HashPass();
        // GET: DangKi
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult ThemTaiKhoan(KhachHang user)
        {
            try
            {
                KhachHang khachHang = db.KhachHangs.SingleOrDefault(item => item.TaiKhoan == user.TaiKhoan);
                if (khachHang != null)
                    return Json(new { status = false });

                string pass_hash = hp.HassPass(user.MatKhau_MaHoa);
                user.MatKhau_MaHoa = pass_hash;
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