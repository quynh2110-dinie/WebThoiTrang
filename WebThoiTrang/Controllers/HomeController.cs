using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.ViewModel;

namespace WebThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        private WebThoiTrangEntities1 db = new WebThoiTrangEntities1();
        public ActionResult Index(string searchTerm, int? page, string category)
        {
            var model = new HomeProductVM();

            var products = db.SanPham.Where(p=> p.TrangThai == true).AsQueryable();


            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.DanhMuc.TenDanhMuc.Contains(category));
                ViewBag.CategoryHienTai = category;
            }    
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p => p.TenSanPham.Contains(searchTerm));
            }

            model.FeaturedProducts = products.OrderByDescending(p => p.NgayTao).Take(4).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 8;
            model.NewProducts = products.OrderByDescending(p => p.MaSanPham).ToPagedList(pageNumber, pageSize);

            return View(model);
        }
        public ActionResult DanhSachSanPham(string searchTerm, int? page)
        {
            var products = db.SanPham.Where(p => p.TrangThai == true);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.TenSanPham.Contains(searchTerm));
                ViewBag.SearchTerm = searchTerm;
            }

            int pageNumber = (page ?? 1);
            int pageSize = 12;
            var pagedProducts = products.OrderByDescending(p => p.MaSanPham).ToPagedList(pageNumber, pageSize);

            return View(pagedProducts);
        }
    }
}