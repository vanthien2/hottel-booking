using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hottel_booking.Models;

namespace hottel_booking.Controllers
{
    public class TTPhongController : Controller
    {
        // GET: TTPhong
        DataDataContext data = new DataDataContext();

        public ActionResult Index()

        {
            var all_TTP = from tt in data.TrangThaiPhongs select tt;

            return View(all_TTP);
        }

        //-------------Detail-------------------
        public ActionResult Detail(int id)
        {
            var D_TTP = data.TrangThaiPhongs.Where(m => m.matrangthaiPhong == id).First();
            return View(D_TTP);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TrangThaiPhong tl)
        {
            var ten = collection["trangthai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.trangthai = ten;
                data.TrangThaiPhongs.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.TrangThaiPhongs.First(m => m.matrangthaiPhong == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.TrangThaiPhongs.First(m => m.matrangthaiPhong == id);
            var E_TTP = collection["trangthai"];
            theloai.matrangthaiPhong = id;
            if (string.IsNullOrEmpty(E_TTP))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.trangthai = E_TTP;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_TTP = data.TrangThaiPhongs.First(m => m.matrangthaiPhong == id);
            return View(D_TTP);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_TTP = data.TrangThaiPhongs.Where(m => m.matrangthaiPhong == id).First();
            data.TrangThaiPhongs.DeleteOnSubmit(D_TTP);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}