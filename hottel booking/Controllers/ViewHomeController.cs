using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hottel_booking.Models;

namespace hottel_booking.Controllers
{
    public class ViewHomeController : Controller
    {
        // GET: ViewHome
        public DataDataContext data = new DataDataContext();

        // GET: View
        public ActionResult Home()
        {


            ViewBag.LoaiPhong = new SelectList(data.LoaiPhongs, "maloaiPhong", "tenloaiphong");
            ViewBag.TrangthaiThanhToan = new SelectList(data.TrangthaiThanhToans, "mathanhtoan", "trangthai");
            return View();
        }
        public ActionResult Room()
        {


            ViewBag.LoaiPhong = new SelectList(data.LoaiPhongs, "maloaiPhong", "tenloaiphong");
            ViewBag.TrangthaiThanhToan = new SelectList(data.TrangthaiThanhToans, "mathanhtoan", "trangthai");
            return View();
        }
        public ActionResult About()
        {


            ViewBag.LoaiPhong = new SelectList(data.LoaiPhongs, "maloaiPhong", "tenloaiphong");
            ViewBag.TrangthaiThanhToan = new SelectList(data.TrangthaiThanhToans, "mathanhtoan", "trangthai");
            return View();
        }
        
    }
}
 