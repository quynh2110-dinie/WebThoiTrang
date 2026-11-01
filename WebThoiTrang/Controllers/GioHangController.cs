using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
    public class GioHangItem
    {
        public BienTheSanPham BienThe { get; set; }
        public int SoLuong { get; set; }
    }

    public class GioHangController : Controller
    {
        private WebThoiTrangEntities1 db = new WebThoiTrangEntities1();

        private List<GioHangItem> LayGioHang()
        {
            var gio = Session["GioHang"] as List<GioHangItem>;
            if (gio == null)
            {
                gio = new List<GioHangItem>();
                Session["GioHang"] = gio;
            }
            return gio;
        }

        public ActionResult Index()
        {
            return View(LayGioHang());
        }

        [HttpPost]
        public ActionResult ThemVao(int maBienThe, int soLuong)
        {
            var gio = LayGioHang();

            var bt = db.BienTheSanPham.FirstOrDefault(b => b.MaBienThe == maBienThe);

            if (bt == null)
            {
                bt = new BienTheSanPham
                {
                    MaBienThe = maBienThe,
                    KichCo = "M",
                    MauSac = "Đen",
                    GiaBan = 150000,
                    SanPham = new SanPham { TenSanPham = "Sản phẩm mẫu" }
                };
            }

            var item = gio.FirstOrDefault(g => g.BienThe.MaBienThe == maBienThe);
            if (item == null)
                gio.Add(new GioHangItem { BienThe = bt, SoLuong = soLuong });
            else
                item.SoLuong += soLuong;

            return RedirectToAction("Index");
        }

        public ActionResult Xoa(int maBienThe)
        {
            var gio = LayGioHang();
            var item = gio.FirstOrDefault(g => g.BienThe.MaBienThe == maBienThe);
            if (item != null) gio.Remove(item);
            return RedirectToAction("Index");
        }

        public ActionResult ThanhToan()
        {
            var gio = LayGioHang();
            if (gio.Count == 0)
            {
                return RedirectToAction("Index"); 
            }
            return View(gio);
        }

        [HttpPost]
        public ActionResult DatHang(string hoTen, string soDienThoai, string diaChi, string phuongThucThanhToan)
        {

            Session["GioHang"] = new List<GioHangItem>(); 

            ViewBag.ThongBao = "Đơn hàng của bạn đã được ghi nhận.";
            ViewBag.HoTen = hoTen;
            ViewBag.DiaChi = diaChi;

            return View("ThanhCong"); 
        }
    }
}