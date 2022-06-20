using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class AdminHoaDonsController : Controller
    {
        private WebBanHangEntities db = new WebBanHangEntities();

        // GET: Admin/AdminHoaDons
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "AdminLogin");
            }

            Session["HoaDonCho"] = db.HoaDons.Where(c => c.TrangThai.TenTrangThai.Equals("Chờ duyệt đơn hàng")).Count();
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.PhuongThucThanhToan).Include(h => h.TrangThai);
            return View(hoaDons.ToList());
        }

        // GET: Admin/AdminHoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/AdminHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH");
            ViewBag.IDPT = new SelectList(db.PhuongThucThanhToans, "IDPT", "TenPT");
            ViewBag.IDTrangThai = new SelectList(db.TrangThais, "IDTrangThai", "TenTrangThai");
            return View();
        }

        // POST: Admin/AdminHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHD,NgayMua,TongSoluong,TongTien,IDKH,IDPT,IDTrangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Session["HoaDonCho"] = db.HoaDons.Where(c => c.TrangThai.TenTrangThai.Equals("Chờ duyệt đơn hàng")).Count();
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", hoaDon.IDKH);
            ViewBag.IDPT = new SelectList(db.PhuongThucThanhToans, "IDPT", "TenPT", hoaDon.IDPT);
            ViewBag.IDTrangThai = new SelectList(db.TrangThais, "IDTrangThai", "TenTrangThai", hoaDon.IDTrangThai);
            return View(hoaDon);
        }

        // GET: Admin/AdminHoaDons/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            Session["HoaDonCho"] = db.HoaDons.Where(c => c.TrangThai.TenTrangThai.Equals("Chờ duyệt đơn hàng")).Count();
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", hoaDon.IDKH);
            ViewBag.IDPT = new SelectList(db.PhuongThucThanhToans, "IDPT", "TenPT", hoaDon.IDPT);
            ViewBag.IDTrangThai = new SelectList(db.TrangThais, "IDTrangThai", "TenTrangThai", hoaDon.IDTrangThai);
            Session["TrangThai"] = hoaDon.IDTrangThai;
            return View(hoaDon);
        }

        // POST: Admin/AdminHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHD,NgayMua,TongSoluong,TongTien,IDKH,IDPT,IDTrangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                if ((int)Session["TrangThai"] == 1 && hoaDon.IDTrangThai != 1)
                {
                    List<ChiTietHoaDon> cthd = db.ChiTietHoaDons.Where(c => c.IDHD == hoaDon.IDHD).ToList();
                    foreach(ChiTietHoaDon item in cthd)
                    {
                        MatHang mh = db.MatHangs.FirstOrDefault(c => c.IDMH == item.IDMH);
                        mh.SoLuong = mh.SoLuong - item.SoluongMH;
                        
                    }
                }
                else
                {
                    if((int)Session["TrangThai"] != 1 && hoaDon.IDTrangThai == 1)
                    {
                        List<ChiTietHoaDon> cthd = db.ChiTietHoaDons.Where(c => c.IDHD == hoaDon.IDHD).ToList();
                        foreach (ChiTietHoaDon item in cthd)
                        {
                            MatHang mh = db.MatHangs.FirstOrDefault(c => c.IDMH == item.IDMH);
                            mh.SoLuong = mh.SoLuong + item.SoluongMH;
                           
                        }
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Session["HoaDonCho"] = db.HoaDons.Where(c => c.TrangThai.TenTrangThai.Equals("Chờ duyệt đơn hàng")).Count();
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", hoaDon.IDKH);
            ViewBag.IDPT = new SelectList(db.PhuongThucThanhToans, "IDPT", "TenPT", hoaDon.IDPT);
            ViewBag.IDTrangThai = new SelectList(db.TrangThais, "IDTrangThai", "TenTrangThai", hoaDon.IDTrangThai);
            return View(hoaDon);
        }

        // GET: Admin/AdminHoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            Session["HoaDonCho"] = db.HoaDons.Where(c => c.TrangThai.TenTrangThai.Equals("Chờ duyệt đơn hàng")).Count();
            return View(hoaDon);
        }

        // POST: Admin/AdminHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
