using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThoiTrang.Models;
using PagedList;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebThoiTrang.Models.ViewModel
{
    public class HomeProductVM
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<SanPham> FeaturedProducts { get; set; }
        public PagedList.IPagedList<SanPham> NewProducts { get; set; }

    }
}