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
            [HttpPost]

            public ActionResult Home([Bind(Include = "madatPhong,hoten,diachi,email,dienthoai,ngaydatPhong,ngaytraPhong,hinhthucthanhtoan,loaiPhong,succhua,total_amount")] tbl_booking tbl_booking)
            {
                int numberofday = Convert.ToInt32((tbl_booking.ngaydatPhong - tbl_booking.booking_from).TotalDays);

                tbl_room_type objroom = db.tbl_room_type.Single(model => model.room_type_id == tbl_booking.assigned_room);
                decimal Roomprices = Convert.ToDecimal(objroom.room_price);
                decimal TotalAmount = Roomprices * numberofday;
                tbl_booking roombooking = new tbl_booking()
                {
                    customer_name = tbl_booking.customer_name,
                    customer_address = tbl_booking.customer_address,
                    customer_email = tbl_booking.customer_email,
                    customer_phone_no = tbl_booking.customer_phone_no,
                    booking_from = tbl_booking.booking_from,
                    booking_to = tbl_booking.booking_to,
                    payment_type = tbl_booking.payment_type,
                    assigned_room = tbl_booking.assigned_room,
                    no_of_members = tbl_booking.no_of_members,
                    total_amount = TotalAmount,
                };


                if (ModelState.IsValid)
                {
                    db.tbl_booking.Add(roombooking);
                    db.SaveChanges();
                    return RedirectToAction("Home");
                }

                ViewBag.assigned_room = new SelectList(db.tbl_room_type, "room_type_id", "room_name", tbl_booking.assigned_room);
                ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
                return View(tbl_booking);
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
 