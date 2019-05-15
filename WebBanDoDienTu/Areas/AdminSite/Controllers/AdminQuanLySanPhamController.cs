using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanDoDienTu.Models.Common;
using WebBanDoDienTu.Models.EF;


namespace WebBanDoDienTu.Areas.AdminSite.Controllers
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
        [HasCredential(Quyen = 1)]
        public ActionResult SuaSanPham(int MaSach)
        {
            var TatCaTheLoai = db.TheLoais.ToList();
            var TatCaNSX = db.NSXes.ToList();
            ViewBag.TatCaTheLoai = TatCaTheLoai;
            ViewBag.TatCaNXS = TatCaNSX;

            //var sach = db.Saches.Join(db.Nhaxuatbans, s => s.Manxb, nxb => nxb.Manxb, (s, nxb) => s)
            //                          .Join(db.Chudes, s => s.Macd, chude => chude.Macd, (s, chude) => s)
            //                          .Join(db.Tacgias, s => s.Matacgia, tacgia => tacgia.Matacgia, (s, tacgia) => s)
            //                          .Where(s => s.Masach == MaSach)
            //                          .First();
            SanPham sanpham = db.SanPhams.Find(MaSach);
            sanpham.Gia = sanpham.Gia != null ? sanpham.Gia : 0;
            sanpham.GiaKM = sanpham.GiaKM != null ? sanpham.GiaKM : 0;
            //sach.Mota = sach.Mota != null ? sach.Mota : "không có mô tả";
            //sach.Motangangon = sach.Motangangon != null ? sach.Motangangon : "không có mô tả";
            return View(sanpham);
        }
        [HttpPost]
        [HasCredential(Quyen = 1)]
        public ActionResult SuaSanPham(SanPham sanpham, HttpPostedFileBase Hinhminhhoa)
        {

            var a = sanpham;
            if (Hinhminhhoa != null && Hinhminhhoa.ContentLength > 0)
            {
                var TenAnh = Path.GetFileName(Hinhminhhoa.FileName);
                var DuongDan = Path.Combine(Server.MapPath("~/Assets/images/"), TenAnh);
                sanpham.AnhDaiDien = TenAnh;
                Hinhminhhoa.SaveAs(DuongDan);
            }
            //sach.Donvitinh = "VNĐ";
            sanpham.Ngay = DateTime.Now;
            var sanphamcu = db.SanPhams.Find(sanpham.SanPhamID);
            db.Entry(sanphamcu).CurrentValues.SetValues(sanpham);
            db.SaveChanges();
            return RedirectToAction("TatCaSanPham");

        }
        [HttpPost]
        [HasCredential(Quyen = 1)]
        public JsonResult XoaSanPham(int MaSanPham)
        {
            try
            {
                SanPham sanpham = db.SanPhams.Find(MaSanPham);
                db.SanPhams.Remove(sanpham);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }

        }
        public ActionResult TimKiem(string TenSanPham)
        {
            List<SanPham> lstSanPham = db.SanPhams.Where(x => x.TenSanPham.Contains(TenSanPham)).ToList();
            return View("TatCaSanPham", lstSanPham);
        }
    }
}