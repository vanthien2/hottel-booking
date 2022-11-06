using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hottel_booking.Models;

namespace hottel_booking.Controllers
{
    public class TTThanhtoanController : Controller
    {
        // GET: TTThanhtoan
        DataDataContext data = new DataDataContext();

        public ActionResult Index()

        {
            var all_TTTT = from tt in data.TrangthaiThanhToans select tt;

            return View(all_TTTT);
        }

        //-------------Detail-------------------
        public ActionResult Detail(int id)
        {
            var D_TTTT = data.TrangthaiThanhToans.Where(m => m.mathanhtoan == id).First();
            return View(D_TTTT);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TrangthaiThanhToan tl)
        {
            var ten = collection["trangthai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.trangthai = ten;
                data.TrangthaiThanhToans.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.TrangthaiThanhToans.First(m => m.mathanhtoan == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.TrangthaiThanhToans.First(m => m.mathanhtoan == id);
            var E_TTTT = collection["trangthai"];
            theloai.mathanhtoan = id;
            if (string.IsNullOrEmpty(E_TTTT))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.trangthai = E_TTTT;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_TTTT = data.TrangthaiThanhToans.First(m => m.mathanhtoan == id);
            return View(D_TTTT);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_TTTT = data.TrangthaiThanhToans.Where(m => m.mathanhtoan == id).First();
            data.TrangthaiThanhToans.DeleteOnSubmit(D_TTTT);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}