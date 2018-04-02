using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IDH7A1.Models;

namespace IDH7A1.Controllers
{
    public class MomentRoomsController : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();

        // GET: MomentRooms/Create
        public ActionResult Create()
        {
            ViewBag.MomentId = new SelectList(db.Moments, "Id", "Name");
            ViewBag.RoomKey = new SelectList(db.Rooms, "Key", "Key");
            ViewBag.SurveillantId = new SelectList(db.Surveillants, "Id", "Name");
            return View();
        }

        // POST: MomentRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MomentId,RoomKey,SurveillantId")] MomentRoom momentRoom)
        {
            if (ModelState.IsValid)
            {
                db.MomentRooms.Add(momentRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MomentId = new SelectList(db.Moments, "Id", "Name", momentRoom.MomentId);
            ViewBag.RoomKey = new SelectList(db.Rooms, "Key", "Key", momentRoom.RoomKey);
            ViewBag.SurveillantId = new SelectList(db.Surveillants, "Id", "Name");
            return View(momentRoom);
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
