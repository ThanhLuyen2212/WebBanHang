﻿using System;
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
    public class AdminLoaiMatHangsController : Controller
    {
        private WebBanHangEntities db = new WebBanHangEntities();

        // GET: Admin/AdminLoaiMatHangs
        public ActionResult Index()
        {
            return View(db.LoaiMatHangs.ToList());
        }

        // GET: Admin/AdminLoaiMatHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // GET: Admin/AdminLoaiMatHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLoaiMatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLoaiMH,TenLoaiMH")] LoaiMatHang loaiMatHang)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMatHangs.Add(loaiMatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMatHang);
        }

        // GET: Admin/AdminLoaiMatHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // POST: Admin/AdminLoaiMatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLoaiMH,TenLoaiMH")] LoaiMatHang loaiMatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMatHang);
        }

        // GET: Admin/AdminLoaiMatHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            if (loaiMatHang == null)
            {
                return HttpNotFound();
            }
            return View(loaiMatHang);
        }

        // POST: Admin/AdminLoaiMatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiMatHang loaiMatHang = db.LoaiMatHangs.Find(id);
            db.LoaiMatHangs.Remove(loaiMatHang);
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
