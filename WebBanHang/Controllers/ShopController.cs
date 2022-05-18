using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;

namespace WebBanHang.Controllers
{
    public class ShopController : Controller
    {

        WebBanHangEntities data = new WebBanHangEntities();
        // GET: Shop

        public ActionResult Index(string idLoaiMH ,string TenTheLoai, string TenMatHang, int page=1 , int pagelist = 3)
        {
            ViewBag.Category = data.LoaiMatHangs.ToList();
           

            if (TenTheLoai != null)
            {                            
                ViewBag.MatHangTheoTheLoai = data.MatHangs.Where(c => c.LoaiMatHang.TenLoaiMH == TenTheLoai).ToList();              
            }
            else
            if (idLoaiMH != null)
            {
                int a = int.Parse(idLoaiMH.ToString());
                /*ViewBag.MatHangTheoTheLoai = data.MatHangs.Where(c => c.IDLoaiMH == a).ToList();*/
                return View(data.MatHangs.Where(c => c.IDLoaiMH == a).ToList());
            }
            else          
            if(TenMatHang != null)
            {
                /*ViewBag.MatHangTheoTheLoai = data.MatHangs.Where(c => c.TenMH == TenMatHang).ToList();*/
                return View(data.MatHangs.Where(c => c.TenMH == TenMatHang).ToList());
            }
            else
            {                
          /*      ViewBag.MatHangTheoTheLoai = data.MatHangs.ToList();*/
                /*ViewBag.MatHangTheoTheLoai = data.MatHangs.OrderByDescending(x => x.IDLoaiMH).ToPagedList(1, 2);*/
                return View(data.MatHangs.OrderByDescending(x => x.IDLoaiMH).ToPagedList(page, pagelist));
            }
            return View();

        }

        
    }
}
