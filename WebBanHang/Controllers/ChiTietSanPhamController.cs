﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        WebBanHangEntities data = new WebBanHangEntities();
        // GET: ChiTietSanPham
        public ActionResult Index(int id)
        {
            return View(data.MatHangs.FirstOrDefault(c => c.IDMH == id));
        }
    }
}