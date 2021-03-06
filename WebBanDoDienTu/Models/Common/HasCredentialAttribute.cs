﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.EF;

namespace WebBanDoDienTu.Models.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public int Quyen { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (KhachHang)HttpContext.Current.Session["ADMIN_SESSION"];
            if(session != null && session.Quyen == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/AdminSite/Views/AdminDangNhap/Index.cshtml"
            };
        }
    }
}