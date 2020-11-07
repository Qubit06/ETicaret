using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Models;

namespace ETicaret.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CategoryList()
        {
            var db = new Db();
            var list = db.Kategoris.ToList();
            return View(list);
        }
        public ActionResult ProductList(int id)
        {
            var db = new Db();
            var uruns = db.Uruns.Where(x => x.KategoriID == id).Include(u => u.Kategori);
            return View(uruns.ToList());
        }
        public ActionResult OrderList()
        {
            var db = new Db();
    
            
            var query = from s in db.Sepets
                        join u in db.Uruns on s.UrunID equals u.ID
                        where s.Durum==2
                        select new
                        {
                            u.Marka,
                            u.Model,
                            u.BirimFiyat,
                            u.StokAdet
                        };


          return Json(query, JsonRequestBehavior.AllowGet);
        }
        //durum 1 ise sepette
        //durum 0 ise pasif
        //durum 2 ise sepet onay ve admin ekrana düşer.
        public ActionResult BasketAdd(int id)
        {
            var db = new Db();
            var urun = db.Uruns.Where(x => x.ID == id).FirstOrDefault();
            int KullaniciId = Convert.ToInt32(Session["KullaniciGirisID"].ToString());
            var sepet = db.Sepets.Where(x => x.KullaniciID == KullaniciId &&
                x.Durum == 1).FirstOrDefault();
            if (sepet == null)
            {
                var yeniSepet = new Sepet {
                    UrunID= urun.ID,
                    KullaniciID = KullaniciId ,
                    Durum = 1,
                    OlusturulmaTarih = DateTime.Now
                };
                sepet = db.Sepets.Add(yeniSepet);
               
                db.SaveChanges();
            }
           
                var sepetUrun = new SepetUrunler
                {
                    UrunID = urun.ID,
                    SepetID = sepet.ID,
                    Adet = 1,
                    OlusturanKullaniciID =KullaniciId,
                    OlusturulmaTarih = DateTime.Now,
                    Urun = urun
                };
                db.SepetUrunler.Add(sepetUrun);
            urun.StokAdet -= 1;
            db.SaveChanges();

            Response.Redirect("~/Home/ProductList/"+urun.KategoriID.ToString());
            return null; 
        }
    }
}