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
    public class AdminMatHangsController : Controller
    {
        private WebBanHangEntities db = new WebBanHangEntities();

        // GET: Admin/AdminMatHangs
        public ActionResult Index()
        {
            var matHangs = db.MatHangs.Include(m => m.LoaiMatHang);
            return View(matHangs.ToList());
        }

        // GET: Admin/AdminMatHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // GET: Admin/AdminMatHangs/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaiMH = new SelectList(db.LoaiMatHangs, "IDLoaiMH", "TenLoaiMH");
            return View();
        }

        // POST: Admin/AdminMatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMH,TenMH,IDLoaiMH,MoTa,DonGia,HinhAnh1,HinhAnh2,HinhAnh3")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoaiMH = new SelectList(db.LoaiMatHangs, "IDLoaiMH", "TenLoaiMH", matHang.IDLoaiMH);
            return View(matHang);
        }

        // GET: Admin/AdminMatHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaiMH = new SelectList(db.LoaiMatHangs, "IDLoaiMH", "TenLoaiMH", matHang.IDLoaiMH);
            return View(matHang);
        }

        // POST: Admin/AdminMatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMH,TenMH,IDLoaiMH,MoTa,DonGia,HinhAnh1,HinhAnh2,HinhAnh3")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoaiMH = new SelectList(db.LoaiMatHangs, "IDLoaiMH", "TenLoaiMH", matHang.IDLoaiMH);
            return View(matHang);
        }

        // GET: Admin/AdminMatHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: Admin/AdminMatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            db.MatHangs.Remove(matHang);
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
