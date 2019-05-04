using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.EF;

namespace WebBanDoDienTu.Areas.AdminSite.Controllers
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