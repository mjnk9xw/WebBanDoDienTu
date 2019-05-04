using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.EF;

namespace WebBanSach.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        private ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            string name = Request.Form["userName"];
            string email = Request.Form["userEmail"];
            string phone = Request.Form["userPhone"];
            string msg = Request.Form["userMsg"];
            db.LienHes.Add(new LienHe {
                 HoTen = name,
                 Email = email,
                 Phone = phone,
                 NoiDung = msg,
            });
            db.SaveChanges();
            return View("Index");
        }
    }
}