using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class XacNhanDonHangController : Controller
    {
        WebBanHangEntities data = new WebBanHangEntities();
        // GET: XacNhanDonHang


       
/*        public ActionResult XacNhan(HoaDon hoaDon)
        {
            HoaDon hoaDon1 = (HoaDon)Session["HoaDon"];
            GioHang gioHang = (GioHang)Session["GioHang"];
            
            if(hoaDon1 == null || gioHang == null) return RedirectToAction("Index", "Login");

            hoaDon = hoaDon1;
            ViewBag.HoaDon = hoaDon1;
            ViewBag.GioHang = gioHang;

            ViewData["PhuongThucThanhToan"] = new SelectList(data.PhuongThucThanhToans.ToList(), "IDPT", "TenPT",hoaDon1.PhuongThucThanhToan);

            hoaDon1.IDTrangThai = 1;

            data.SaveChanges();

            return View();
        }*/

        // GET: Admin/AdminHoaDons/Edit/5
        public ActionResult XacNhan(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = data.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return RedirectToAction("Index", "Login");
            }

            GioHang gioHang = (GioHang)Session["GioHang"];         

         
            ViewBag.HoaDon = hoaDon;
            ViewBag.GioHang = gioHang;   

            ViewData["IDPT"] = new SelectList(data.PhuongThucThanhToans, "IDPT", "TenPT", hoaDon.IDPT);
           
            return View(hoaDon);
        }

        // POST: Admin/AdminHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhan(HoaDon hoaDon)
        {       
            
            if (ModelState.IsValid)
            {
                data.Entry(hoaDon).State = System.Data.Entity.EntityState.Modified;
                HoaDon hoaDon1 = (HoaDon)Session["HoaDon"];
               
                hoaDon.IDKH = hoaDon1.IDKH;
                hoaDon.IDTrangThai = 1;
                hoaDon.TongSoluong = hoaDon1.TongSoluong;
                hoaDon.TongTien = hoaDon1.TongTien;

                data.SaveChanges();
                Session.Remove("HoaDon");
                Session.Remove("GioHang");
                Session.Remove("SoLuongHangTrongGioHang");
                return RedirectToAction("MuaThanhCong","ThongBao");
            }

            GioHang gioHang = (GioHang)Session["GioHang"];


            ViewBag.HoaDon = hoaDon;
            ViewBag.GioHang = gioHang;

            ViewData["PhuongThucThanhToan"] = new SelectList(data.PhuongThucThanhToans.ToList(), "IDPT", "TenPT", hoaDon.PhuongThucThanhToan);

            hoaDon.IDTrangThai = 1;

            ViewBag.IDKH = new SelectList(data.KhachHangs, "IDKH", "TenKH", hoaDon.IDKH);
            ViewBag.IDPT = new SelectList(data.PhuongThucThanhToans, "IDPT", "TenPT", hoaDon.IDPT);
            ViewBag.IDTrangThai = new SelectList(data.TrangThais, "IDTrangThai", "TenTrangThai", hoaDon.IDTrangThai);
            
            return View(hoaDon);
        }

    }
}