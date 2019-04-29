using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.EF;

namespace WebBanSach.Areas.AdminSite.Controllers
{
    public class AdminTrangChuController : Controller
    {
        // GET: AdminSite/AdminTrangChu
        public ActionResult Index()
        {
            return View();
        }
    }
}