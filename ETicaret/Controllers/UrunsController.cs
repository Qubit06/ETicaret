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
    public class UrunsController : Controller
    {
        private Db db = new Db();
        public ActionResult Index(int? id)
        {
           if(id==null)
            {
                return View(db.Uruns.ToList());
            }
            else
            {
                Response.Write(id);
                var uruns = db.Uruns.Where(x => x.KategoriID == id).Include(u => u.Kategori);
                return View(uruns.ToList());
            }
        }
        /*
        public ActionResult Index(int id)
        {
            Response.Write(id);
            var uruns = db.Uruns.Where(x => x.KategoriID == id).Include(u => u.Kategori);
            return View(uruns.ToList());
        }*/

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

      
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAd");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,KategoriID,Marka,Model,ResimUrl,Aciklama,BirimFiyat,KDV,Indirim,StokAdet,Aktif,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Uruns.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAd", urun.KategoriID);
            return View(urun);
        }

  
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAd", urun.KategoriID);
            return View(urun);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,KategoriID,Marka,Model,ResimUrl,Aciklama,BirimFiyat,KDV,Indirim,StokAdet,Aktif,OlusturulmaTarih,OlusturanKullaniciID,GuncellemeTarih,GuncellemeKullaniciID")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAd", urun.KategoriID);
            return View(urun);
        }

  
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Uruns.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = db.Uruns.Find(id);
            db.Uruns.Remove(urun);
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
