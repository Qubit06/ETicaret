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
    public class SepetsController : Controller
    {
        private Db db = new Db();

        // GET: Sepets
        public ActionResult Index()
        {
            return View(db.Sepets.ToList());
        }

        // GET: Sepets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<SepetUrunler> SepetUrunler = db.SepetUrunler.Where(x => x.SepetID == id).ToList();

            if (SepetUrunler == null)
                return HttpNotFound();
            foreach(var surun in SepetUrunler)
            {
                surun.Urun = db.Uruns.Find(surun.UrunID);
            }
            

            return View(SepetUrunler);
        }

        // GET: Sepets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sepets/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KullaniciID,Durum,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] Sepet sepet)
        {
            if (ModelState.IsValid)
            {
                db.Sepets.Add(sepet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sepet);
        }

        // GET: Sepets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = db.Sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            sepet.Durum = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Sepets/Delete/5
        public ActionResult Delete(int? id)
        {
            var urun = db.Uruns.Where(x => x.ID == id).FirstOrDefault();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = db.Sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
           
            return View(sepet);
        }

        // POST: Sepets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sepet sepet = db.Sepets.Find(id);
            db.Sepets.Remove(sepet);
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
