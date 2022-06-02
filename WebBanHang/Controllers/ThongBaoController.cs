using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
       
        public ActionResult CacMatHangDaMua()
        {

            if (Session["KhachHang"] != null)
            {
                KhachHang khachhang = (KhachHang)Session["KhachHang"];
                List<HoaDon> listhoadon = data.HoaDons.Where(c => c.IDKH == khachhang.IDKH).ToList();
                List<ChiTietHoaDon> listchitiethoadon = new List<ChiTietHoaDon>();
                foreach (HoaDon item in listhoadon)
                {
                    List<ChiTietHoaDon> temp = data.ChiTietHoaDons.Where(c => c.IDHD == item.IDHD).ToList();
                    listchitiethoadon = listchitiethoadon.Concat(temp).ToList();

                }
                listchitiethoadon = listchitiethoadon.Distinct().ToList();
                ViewBag.chitietdonhang = listchitiethoadon;

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }



        public ActionResult CacDonHangDangCho()
        {
            if (Session["KhachHang"] != null)
            {
                KhachHang khachhang = (KhachHang)Session["KhachHang"];
                List<HoaDon> listhoadon = data.HoaDons.Where(c => c.IDKH == khachhang.IDKH && c.IDTrangThai == 1).ToList();               
                ViewBag.cachoadondangcho = listhoadon;

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public ActionResult HuyDonHang(FormCollection form)
        {
            if (Session["KhachHang"] != null)
            {
                int id = int.Parse(form["ID HoaDon"].ToString());

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                HoaDon hoaDon = data.HoaDons.FirstOrDefault(c => c.IDHD == id);

                if (hoaDon == null)
                {
                    return HttpNotFound();
                }

                data.HoaDons.Remove(hoaDon);
                data.SaveChanges();

                return RedirectToAction("CacDonHangDangCho", "ThongBao");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult TatCaCacDonHang()
        {

            if (Session["KhachHang"] != null)
            {
                KhachHang khachhang = (KhachHang)Session["KhachHang"];
                List<HoaDon> listhoadon = data.HoaDons.Where(c => c.IDKH == khachhang.IDKH).ToList();
                ViewBag.tatcacacdonhang = listhoadon;

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}