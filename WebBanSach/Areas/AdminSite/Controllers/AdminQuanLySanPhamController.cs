﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.Common;
using WebBanSach.Models.EF;


namespace WebBanSach.Areas.AdminSite.Controllers
{
    public class AdminQuanLySanPhamController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        // GET: AdminSite/AdminQuanLySach
        [HasCredential(Quyen = 1)]
        public ActionResult TatCaSanPham()
        {
            var TatCaSanPham = db.SanPhams.Join(db.NSXes, sp => sp.NSXID, nsx => nsx.NSXID, (sp, nsx) => sp)
                                      .Join(db.TheLoais, sp => sp.TheLoaiID, tl => tl.TheLoaiID, (sp, tl) => sp)
                                      .OrderByDescending(sp => sp.SanPhamID)
                                      .ToList();
            return View(TatCaSanPham);
        }
        [HasCredential(Quyen = 1)]
        public ActionResult ThemSanPham()
        {

            var TatCaTheLoai = db.TheLoais.ToList();
            var TatCaNSX = db.NSXes.ToList();
            ViewBag.TatCaTheLoai = TatCaTheLoai;
            ViewBag.TatCaNSX = TatCaNSX;
            return View();
        }
        [HttpPost]
        [HasCredential(Quyen = 1)]
        public ActionResult ThemSanPham(SanPham sanpham, HttpPostedFileBase Hinhminhhoa)
        {
            if (ModelState.IsValid)
            {
                if (Hinhminhhoa != null && Hinhminhhoa.ContentLength > 0)
                {
                    var TenAnh = Path.GetFileName(Hinhminhhoa.FileName);
                    var DuongDan = Path.Combine(Server.MapPath("~/Assets/images/"), TenAnh);
                    sanpham.AnhDaiDien = TenAnh;
                    Hinhminhhoa.SaveAs(DuongDan);
                }
                else
                {
                    sanpham.AnhDaiDien = "Ecap E2.jpg";
                }
                sanpham.Ngay = DateTime.Now;
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("TatCaSanPham");
            }
            else
            {
                ViewBag.TatCaTheLoai = db.TheLoais.ToList(); ;
                ViewBag.TatCaNSX = db.NSXes.ToList();
                return View(sanpham);
            }


        }
        //[HasCredential(Quyen = 1)]
        //public ActionResult SuaSach(int MaSach)
        //{
        //    var TatCaChuDe = db.Chudes.ToList();
        //    var TatCaTacGia = db.Tacgias.ToList();
        //    var TatCaNXB = db.Nhaxuatbans.ToList();
        //    ViewBag.TatCaChuDe = TatCaChuDe;
        //    ViewBag.TatCaTacGia = TatCaTacGia;
        //    ViewBag.TatCaNXB = TatCaNXB;

        //    //var sach = db.Saches.Join(db.Nhaxuatbans, s => s.Manxb, nxb => nxb.Manxb, (s, nxb) => s)
        //    //                          .Join(db.Chudes, s => s.Macd, chude => chude.Macd, (s, chude) => s)
        //    //                          .Join(db.Tacgias, s => s.Matacgia, tacgia => tacgia.Matacgia, (s, tacgia) => s)
        //    //                          .Where(s => s.Masach == MaSach)
        //    //                          .First();
        //    Sach sach = db.Saches.Find(MaSach);
        //    sach.Dongia = sach.Dongia != null ? sach.Dongia : 0;
        //    sach.Giakm = sach.Giakm != null ? sach.Giakm : 0;
        //    sach.Mota = sach.Mota != null ? sach.Mota : "không có mô tả";
        //    sach.Motangangon = sach.Motangangon != null ? sach.Motangangon : "không có mô tả";
        //    return View(sach);
        //}
        //[HttpPost]
        //[HasCredential(Quyen = 1)]
        //public ActionResult SuaSach(Sach sach, HttpPostedFileBase Hinhminhhoa)
        //{

        //    var a = sach;
        //    if (Hinhminhhoa != null && Hinhminhhoa.ContentLength > 0)
        //    {
        //        var TenAnh = Path.GetFileName(Hinhminhhoa.FileName);
        //        var DuongDan = Path.Combine(Server.MapPath("~/Assets/images/books/"), TenAnh);
        //        sach.Hinhminhhoa = TenAnh;
        //        Hinhminhhoa.SaveAs(DuongDan);
        //    }
        //    sach.Donvitinh = "VNĐ";
        //    sach.Ngaycapnhat = DateTime.Now;
        //    var sachcu = db.Saches.Find(sach.Masach);
        //    db.Entry(sachcu).CurrentValues.SetValues(sach);
        //    db.SaveChanges();
        //    return RedirectToAction("TatCaSach");

        //}
        //[HttpPost]
        //[HasCredential(Quyen = 1)]
        //public JsonResult XoaSach(int MaSach)
        //{
        //    try
        //    {
        //        Sach sach = db.Saches.Find(MaSach);
        //        db.Saches.Remove(sach);
        //        db.SaveChanges();
        //        return Json(new { status = true });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { status = false });
        //    }

        //}
        //public ActionResult TimKiem(string TenSach)
        //{
        //    List<Sach> lstSach = db.Saches.Where(x => x.Tensach.Contains(TenSach)).ToList();
        //    return View("TatCaSach", lstSach);
        //}
    }
}