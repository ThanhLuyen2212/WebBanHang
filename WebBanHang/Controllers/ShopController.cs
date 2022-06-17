using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;

namespace WebBanHang.Controllers
{
    public class ShopController : Controller
    {

        WebBanHangEntities data = new WebBanHangEntities();
        // GET: Shop

        public ActionResult Index(string TenMatHang, int page=1 , int pagelist = 6)
        {
            ViewBag.Category = data.LoaiMatHangs.ToList();                     
            if(TenMatHang != null)
            {
                return View(data.MatHangs.Where(c => c.TenMH.ToLower().Contains(TenMatHang.ToLower())).OrderByDescending(c => c.IDMH).ToPagedList(page, pagelist));
            }
            else
            {                
                return View(data.MatHangs.OrderByDescending(x => x.IDLoaiMH).ToPagedList(page, pagelist));
            }
            return View(data.MatHangs.OrderByDescending(x => x.IDLoaiMH).ToPagedList(page, pagelist));

        }

        
    }
}
