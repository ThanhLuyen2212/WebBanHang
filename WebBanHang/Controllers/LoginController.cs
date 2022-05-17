﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class LoginController : Controller
    {
        WebBanHangEntities data = new WebBanHangEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(KhachHang user)
        {
            KhachHang check = data.KhachHangs.Where(s=> s.UserName == user.UserName && s.Password == user.Password).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai thông tin tài khoản";
                return View("Index");
            }
            else
            {
                data.Configuration.ValidateOnSaveEnabled = false;

                Session["UserName"] = check.UserName;
                Session["Password"] = check.Password;
                Session["KhachHang"] = check;
              

                return RedirectToAction("Index", "Home");
            }
        }
    }
}