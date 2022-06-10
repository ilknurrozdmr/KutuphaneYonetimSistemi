using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN t)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x => x.KULLANICI == t.KULLANICI && x.SIFRE == t.SIFRE);
            if(bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["Kullanici"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}