using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CanvasWeb.Models.ADO;
using Microsoft.AspNet.Identity;

namespace CanvasWeb.Controllers
{
    public class CanvasController : Controller
    {
        private CanvasWebEntities db = new CanvasWebEntities();

        // GET: Canvas
        public ActionResult Index()
        {
            var canvas = db.Canvas.Include(c => c.AspNetUser);
            return View(canvas.ToList());
        }



        public JsonResult detailasjson(int id)
        {
           
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Canvas.Where(e => e.CanvasId == id && User.Identity.GetUserId<int>() == e.UserId).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        // GET: Canvas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canva canva = db.Canvas.Find(id);
            if (canva == null)
            {
                return HttpNotFound();
            }
            return View(canva);
        }

        // GET: Canvas/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Canvas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CanvasId,Key_Partners,Value_Propositions,Customer_Relationships,Customer_Segments,Key_Resources,Channels,Cost_Structure,Revenue_Streams,UserId")] Canva canva)
        {
            if (ModelState.IsValid)
            {
                db.Canvas.Add(canva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", canva.UserId);
            return View(canva);
        }

        // GET: Canvas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canva canva = db.Canvas.Find(id);
            if (canva == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", canva.UserId);
            return View(canva);
        }

        // POST: Canvas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CanvasId,Key_Partners,Value_Propositions,Customer_Relationships,Customer_Segments,Key_Resources,Channels,Cost_Structure,Revenue_Streams,UserId")] Canva canva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", canva.UserId);
            return View(canva);
        }

        // GET: Canvas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canva canva = db.Canvas.Find(id);
            if (canva == null)
            {
                return HttpNotFound();
            }
            return View(canva);
        }

        // POST: Canvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canva canva = db.Canvas.Find(id);
            db.Canvas.Remove(canva);
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
