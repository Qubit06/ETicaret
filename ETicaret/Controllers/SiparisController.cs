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
    public class SiparisController : Controller
    {
        private Db db = new Db();

        // GET: Siparis
        public ActionResult Index()
        {
            var siparis = db.Siparis.Include(s => s.Kullanici).Include(s => s.Urun);
            return View(siparis.ToList());
        }

        // GET: Siparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: Siparis/Create
        public ActionResult Create()
        {
            ViewBag.KullaniciID = new SelectList(db.Kullanicis, "ID", "Ad");
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad");
            return View();
        }

        // POST: Siparis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KullaniciID,UrunID,SepetID,ToplamUrunFiyat,ToplamKDVFiyat,TotalIndirimFiyat,ToplamFiyat,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Siparis.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KullaniciID = new SelectList(db.Kullanicis, "ID", "Ad", siparis.KullaniciID);
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad", siparis.UrunID);
            return View(siparis);
        }

        // GET: Siparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.KullaniciID = new SelectList(db.Kullanicis, "ID", "Ad", siparis.KullaniciID);
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad", siparis.UrunID);
            return View(siparis);
        }

        // POST: Siparis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KullaniciID,UrunID,SepetID,ToplamUrunFiyat,ToplamKDVFiyat,TotalIndirimFiyat,ToplamFiyat,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KullaniciID = new SelectList(db.Kullanicis, "ID", "Ad", siparis.KullaniciID);
            ViewBag.UrunID = new SelectList(db.Uruns, "ID", "Ad", siparis.UrunID);
            return View(siparis);
        }

        // GET: Siparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
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
