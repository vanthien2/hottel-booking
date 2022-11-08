using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hottel_booking.Models;


namespace hottel_booking.Controllers
{
    public class danhsachPhongController : Controller
    {
        // GET: danhsachPhong
        DataDataContext data = new DataDataContext();
        public ActionResult ListPhong()
        {
            var all_Phong = from ss in data.Phongs select ss;

            return View(all_Phong);
        }
    }
}