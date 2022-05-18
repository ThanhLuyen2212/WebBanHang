using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DatHangThanhCong()
        {
            return View();
        }

        public ActionResult CacDonHang()
        {
            return View();
        }
    }
}