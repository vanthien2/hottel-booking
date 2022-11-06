using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hottel_booking.Models;


namespace hottel_booking.Controllers
{
    public class LoaiPhongController : Controller
    {
        // GET: LoaiPhong
        DataDataContext data = new DataDataContext();

        public ActionResult Index()

        {
            var all_LoaiPhong = from tt in data.LoaiPhongs select tt;

            return View(all_LoaiPhong);
        }

        //-------------Detail-------------------
        public ActionResult Detail(int id)
        {
            var D_theloai = data.LoaiPhongs.Where(m => m.maloaiPhong == id).First();
            return View(D_theloai);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, LoaiPhong tl)
        {
            var ten = collection["tenloaiphong"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.tenloaiphong = ten;
                data.LoaiPhongs.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.LoaiPhongs.First(m => m.maloaiPhong == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.LoaiPhongs.First(m => m.maloaiPhong == id);
            var E_tenloai = collection["tenloaiphong"];
            theloai.maloaiPhong = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.tenloaiphong = E_tenloai;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_theloai = data.LoaiPhongs.First(m => m.maloaiPhong == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = data.LoaiPhongs.Where(m => m.maloaiPhong== id).First();
            data.LoaiPhongs.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}
