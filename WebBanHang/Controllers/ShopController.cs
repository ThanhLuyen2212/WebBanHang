﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ShopController : Controller
    {

        WebBanHangEntities data = new WebBanHangEntities();
        // GET: Shop

        public ActionResult Index(string idLoaiMH , string TenMatHang)
        {
            ViewBag.Category = data.LoaiMatHangs.ToList();
            
            if (idLoaiMH != null)
            {
                int a = int.Parse(idLoaiMH.ToString());
                ViewBag.MatHangTheoTheLoai = data.MatHangs.Where(c => c.IDLoaiMH == a).ToList();
            }
            else          
            if(TenMatHang != null)
            {
                ViewBag.MatHangTheoTheLoai = data.MatHangs.Where(c => c.TenMH == TenMatHang).ToList();
            }
            else
            {
                ViewBag.MatHangTheoTheLoai = data.MatHangs.ToList();
            }
            return View();

        }
    }
}