using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaret;
using ETicaret.Models;

namespace ETicaret.Controllers
{
    public class SepetUrunlersController : Controller
    {
        private Db db = new Db();

        // GET: SepetUrunlers
        public ActionResult Index()
        {
            var sepetUrunler = db.SepetUrunler.Include(s => s.Urun);
            return View(sepetUrunler.ToList());
        }

        // GET: SepetUrunlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SepetUrunler sepetUrunler = db.SepetUrunler.Find(id);
            if (sepetUrunler == null)
            {
                return HttpNotFound();
            }
            return View(sepetUrunler);
        }

        // GET: SepetUrunlers/Create
        public ActionResult Create()
        {
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad");
            return View();
        }

        // POST: SepetUrunlers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SepetID,UrunID,Adet,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] SepetUrunler sepetUrunler)
        {
            if (ModelState.IsValid)
            {
                db.SepetUrunler.Add(sepetUrunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad", sepetUrunler.UrunID);
            return View(sepetUrunler);
        }

        // GET: SepetUrunlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SepetUrunler sepetUrunler = db.SepetUrunler.Find(id);
            if (sepetUrunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad", sepetUrunler.UrunID);
            return View(sepetUrunler);
        }

        // POST: SepetUrunlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SepetID,UrunID,Adet,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] SepetUrunler sepetUrunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sepetUrunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad", sepetUrunler.UrunID);
            return View(sepetUrunler);
        }

        // GET: SepetUrunlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SepetUrunler sepetUrunler = db.SepetUrunler.Find(id);
            if (sepetUrunler == null)
            {
                return HttpNotFound();
            }
            return View(sepetUrunler);
        }

        // POST: SepetUrunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SepetUrunler sepetUrunler = db.SepetUrunler.Find(id);
            db.SepetUrunler.Remove(sepetUrunler);
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
