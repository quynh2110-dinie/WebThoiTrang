using System.Linq;
using System.Web.Mvc;
using WebThoiTrang.Models;

namespace WebThoiTrang.Controllers
{
    public class SanPhamController : Controller
    {

        public ActionResult Detail(int id)
        {
            var sp = new SanPham
            {
                MaSanPham = id,
                TenSanPham = "Sản phẩm mẫu " + id,
                MoTa = "Đây là mô tả sản phẩm mẫu. Áo chất liệu cotton thoáng mát.",
                HinhAnhDaiDien = "/Content/images/1793352779496_122362366307774886_7119991426278928347_e0ef25322cd005807fbc30942aa99bb3.jpg",
                DanhMuc = new DanhMuc { TenDanhMuc = "Thời trang" },
                BienTheSanPham = new System.Collections.Generic.List<BienTheSanPham>
        {
            new BienTheSanPham { MaBienThe = 1, KichCo = "M", MauSac = "Đen", GiaBan = 150000, SoLuongTon = 10, TrangThai = true },
            new BienTheSanPham { MaBienThe = 2, KichCo = "L", MauSac = "Trắng", GiaBan = 160000, SoLuongTon = 5, TrangThai = true }
        }
            };
            return View(sp);
        }
    }
}