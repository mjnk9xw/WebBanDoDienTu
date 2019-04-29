using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models.Common;
using WebBanSach.Models.EF;

namespace WebBanSach.Controllers
{
    public class ChiTietController : Controller
    {
        ThucTap_NhomEntities db = new ThucTap_NhomEntities();
        private const string CartSession = "CART_SESSION";
        public ActionResult Index(int ID = 1020)
        {
            var sach = db.SanPhams.SingleOrDefault(item => item.SanPhamID == ID);
            if (sach == null)
            {
                Response.StatusCode = 404;
                Response.StatusDescription = "Không có sản này";
            }
            return View(sach);
        }

        [HttpPost]
        public JsonResult AddToCart(int productID, int quantity)
        {
            var listProductInCart = Session[CartSession];
            var listItem = new List<CartItem>();

            if (listProductInCart == null)
            {
                var product = new CartItem();
                product.Product = db.SanPhams.SingleOrDefault(item => item.SanPhamID == productID);
                product.Quantity = quantity;
                listItem.Add(product);
            }
            else
            {
                listItem = (List<CartItem>)listProductInCart;
                bool isExisting = listItem.Exists(item => item.Product.SanPhamID == productID);
                if (isExisting)
                {
                    var product = listItem.SingleOrDefault(item => item.Product.SanPhamID == productID);
                    product.Quantity += quantity;
                }
                else
                {
                    var product = new CartItem();
                    product.Product = db.SanPhams.SingleOrDefault(item => item.SanPhamID == productID);
                    product.Quantity = quantity;
                    listItem.Add(product);
                }
            }
            Session[CartSession] = listItem;
            return Json(new { status = true });
        }
    }
}