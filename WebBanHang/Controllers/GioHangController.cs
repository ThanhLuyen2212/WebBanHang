﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class GioHangController : Controller
    {
        WebBanHangEntities data = new WebBanHangEntities();
        // GET: GioHang
        public GioHang GetHang()
        {
            GioHang gio = Session["GioHang"] as GioHang;
            if ((gio == null) || Session["GioHang"] == null)
            {
                gio = new GioHang();
                Session["GioHang"] = gio;
            }
            return gio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Addto(string id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var gio = data.MatHangs.SingleOrDefault(s => s.IDMH.ToString() == id);
                if (gio != null)
                {
                    GetHang().Add(gio);

                    // Số lượng hàng trong giở là bao nhiêu
                    GioHang gioHang = Session["GioHang"] as GioHang;                    
                    Session["SoLuongHangTrongGioHang"] = gioHang.sum().ToString();
                }
                return RedirectToAction("Show", "GioHang");
            }
        }

        public ActionResult Show()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Shop");
            }
                       

            KhachHang kh = (KhachHang)Session["KhachHang"];  

            GioHang gio = Session["GioHang"] as GioHang;

            return View(gio);
        }

        public ActionResult Update_quantity(FormCollection form)
        {
            GioHang gio = Session["GioHang"] as GioHang;
            string id_MatHang = form["ID MatHang"];
            int quatity = int.Parse(form["quantity"]);

            gio.Update_quantity(id_MatHang, quatity);
    
            Session["SoLuongHangTrongGioHang"] = gio.sum().ToString();

            return RedirectToAction("Show", "GioHang");

        }

        public ActionResult Remove(int id)
        {
            GioHang gio = Session["GioHang"] as GioHang;
            gio.Remove(id);
            
            Session["SoLuongHangTrongGioHang"] = gio.sum().ToString();
            return RedirectToAction("Show", "GioHang"); 
        }


        public PartialViewResult BagMathang()
        {
            int total = 0;
            GioHang gio = Session["GioHang"] as GioHang;
            if(gio != null)
            {
                total = gio.Total();
            }

            ViewBag.InforGio = total;
            return PartialView("BagMatHang");
        }

        public ActionResult Mua_Success()
        {
            return RedirectToAction("Index", "PhongThuThanhToan");
        }

        [HttpPost]
        public ActionResult MuaHang(FormCollection form)
        {
            try
            {
                HoaDon hoadon = new HoaDon();
                if (Session["UserName"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                KhachHang khach = (KhachHang)Session["KhachHang"];
                hoadon.IDKH = khach.IDKH;
                data.HoaDons.Add(hoadon);
                data.SaveChanges();

                // Lấy tưng sản phẩm
                GioHang gio = Session["GioHang"] as GioHang;
                int tongtien = 0;
                int _tongHang = 0;
                foreach (var item in gio.ListHang)
                {
                    _tongHang += item._soLuongHang;

                    if (_tongHang == 0)
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert ('Không có hàng hóa trong giỏ hàng!');</script>");
                    }

                    ChiTietHoaDon detail = new ChiTietHoaDon();
                    detail.IDHD = hoadon.IDHD;
                    detail.IDMH = item.gioHang.IDMH;
                    detail.SoluongMH = item._soLuongHang;

                    tongtien += (int)(item.gioHang.DonGia * item._soLuongHang);

                    data.ChiTietHoaDons.Add(detail);
                    data.SaveChanges();
                }

                hoadon.TongSoluong = _tongHang;
                hoadon.TongTien = tongtien;
                Session["HoaDon"] = hoadon;
                Session["GioHang"] = gio;

                data.SaveChanges();
                //gio.clear();
                return RedirectToAction("XacNhan", "XacNhanDonHang", new { id = hoadon.IDHD });
            }
            catch
            {
                return Content("Vui lòng kiểm tra lại thông tin!");
            }

        }

    }
}