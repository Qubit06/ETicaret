using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class AuthAdminController : AdminControllerBase
    {
      Db db = new Db();
      public ActionResult Login()
        {
            Response.Write(Session["AdminGiris"].ToString());
            if (Session["AdminGiris"].ToString() == " " )
                return View();
           
            else
            {
                Response.Redirect("/");
                return null;
            }
        }
       
        [HttpPost]
        public ActionResult Login(string Mail, string Sifre)

        {
            var dataAdmin= db.Kullanicis.Where(x => x.Mail == Mail && x.Sifre == Sifre && x.Aktif==true && x.Admin==true).ToList();
            var dataKullanici = db.Kullanicis.Where(x => x.Mail == Mail && x.Sifre == Sifre && x.Aktif == true && x.Admin == false).ToList();
           
            if (dataAdmin.Count==1)
            {
                Session["AdminGiris"] = dataAdmin.FirstOrDefault();
                Response.Redirect("~/Kategoris/Index");
            }
            if (dataKullanici.Count == 1)
             {
                Session["KullaniciGiris"] = dataKullanici.FirstOrDefault();
                Session["KullaniciGirisID"] = dataKullanici.FirstOrDefault().ID;
                return Redirect("~/Home/CategoryList");
             }
            else
            {
                ViewBag.LoginError="Hatalı Giriş";
                return View();
            }
           

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("~/AuthAdmin/Login");
        }
    }
}