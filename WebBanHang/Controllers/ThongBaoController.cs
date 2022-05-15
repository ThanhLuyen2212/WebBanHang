using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class ThongBaoController : Controller
    {
        // GET: ThongBao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MuaThanhCong()
        {
            return View();
        }
    }
}