using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLADMIN.ToList();
            return View(degerler);
        }
        public ActionResult Index2()
        {
            var degerler = db.TBLADMIN.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN t)
        {
            db.TBLADMIN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN t)
        {
            var admin = db.TBLADMIN.Find(t.ID);
            admin.KULLANICI = t.KULLANICI;
            admin.SIFRE = t.SIFRE;
            admin.YETKI = t.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}