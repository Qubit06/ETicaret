using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ETicaret.Controllers
{
    public class AdminControllerBase : Controller
    {
       
        protected override void Initialize(RequestContext requestContext)
        {
            
            if (requestContext.HttpContext.Session["AdminGiris"] == null 
                && requestContext.HttpContext.Session["KullaniciGiris"] == null) 
            {
                requestContext.HttpContext.Session["AdminGiris"] = " ";
               // requestContext.HttpContext.Session["KullaniciGiris"] = "GirisYap";
                requestContext.HttpContext.Response.Redirect("~/AuthAdmin/Login");

            }

            base.Initialize(requestContext);
        }
    }
}