﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Areas.Admin.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class AdminThongKeController : Controller
    {
        WebBanHangEntities data = new WebBanHangEntities();
        // GET: Admin/AdminThongKe
        public ActionResult Index()
        {
            return View();
        }

        // thống kê doanh thu theo khách hàng
        public ActionResult ThongKeDoanhThuTheoKhachHang()
        {

            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }

            List<KhachHang> khachHangList = data.KhachHangs.ToList();

            List<ThongKeTheoKhachHang> listThongKe = new List<ThongKeTheoKhachHang>();
           
            
            foreach (var item in khachHangList)
            {
                if (data.HoaDons.FirstOrDefault(c => c.IDKH == item.IDKH) == null) continue;
                ThongKeTheoKhachHang tk = new ThongKeTheoKhachHang();               
                tk.TenKhachHang = item.TenKH;
                tk.SoLuongHangHoaDaMua = int.Parse(data.HoaDons.Where(c => c.IDKH == item.IDKH).Sum(c => c.TongSoluong).ToString());
                tk.SoTienThuVeTuKhachHang = int.Parse(data.HoaDons.Where(c => c.IDKH == item.IDKH).Sum(c => c.TongTien).ToString());
                tk.DoanhThuChoKhachHang = int.Parse(data.HoaDons.Where(c => c.IDKH == item.IDKH).Sum(c => c.TongTien).ToString());
                listThongKe.Add(tk);
            }
             
            return View(listThongKe);           
           
        }

        // Thống kê doang thu theo sản phẩm
        public ActionResult ThongKeDoanhThuTheoSanPham()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }

            List<MatHang> matHangs = data.MatHangs.ToList();

            List<ThongKeTheoSanPham> listThongKe = new List<ThongKeTheoSanPham>();


            foreach (var item in matHangs)
            {
                if (data.ChiTietHoaDons.FirstOrDefault(c => c.IDMH == item.IDMH) == null) continue;
                ThongKeTheoSanPham sp = new ThongKeTheoSanPham();
                sp.TenSanPham = item.TenMH;
                int tmp = int.Parse(data.ChiTietHoaDons.Where(c => c.IDMH == item.IDMH).Sum(c => c.SoluongMH).ToString());
                sp.SoLuongHangHoaBanDuoc = int.Parse(data.ChiTietHoaDons.Where(c => c.IDMH == item.IDMH).Sum(c => c.SoluongMH).ToString());                               
                sp.SoTienHangHoaThuVe = (int)(item.DonGia * tmp);
                sp.DoanhThuChoHangHoa = sp.SoTienHangHoaThuVe;
                listThongKe.Add(sp);
            }

            return View(listThongKe);
        }
    }
}