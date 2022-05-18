using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ThongBaoController : Controller
    {
        WebBanHangEntities data = new WebBanHangEntities();
        // GET: ThongBao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MuaThanhCong()
        {

            return View();
        }

        public ActionResult CacDonHang()
        {
            if (Session["KhachHang"] != null)
            {
                KhachHang khachhang = (KhachHang)Session["KhachHang"];
                ViewBag.HoaDon = data.HoaDons.Where(c => c.IDKH == khachhang.IDKH).ToList();
            }            
            return View();
        }
    }
}