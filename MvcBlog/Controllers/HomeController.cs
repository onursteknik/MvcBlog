using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        mvcblogDB db = new mvcblogDB();
        // GET: Home
        public ActionResult Index(int Page=1)
        {
            var makale = db.Makales.OrderByDescending(m => m.MakaleID).ToPagedList(Page,5);
            return View(makale);
        }
        public ActionResult BlogAra(string Ara=null)
        {
            var aranan = db.Makales.Where(t => t.Baslik.Contains(Ara) || t.Icerik.Contains(Ara)).ToList();
            return View(aranan.OrderByDescending(m=>m.Tarih));
        }

        public ActionResult SonYorumlar()
        {
            return View(db.Yorums.OrderByDescending(m=> m.YorumID).Take(5));
        }
        public ActionResult PopulerMakaleler()
        {
            return View(db.Makales.OrderByDescending(m => m.Okunma).Take(5));
        }
        public ActionResult KategoriMakale(int id)
        {
            var makaleler = db.Makales.Where(m => m.KategoriID == id).ToList();
            return View(makaleler);
        }

        public ActionResult MakaleDetay(int id)
        {
            var makale = db.Makales.Where(m => m.MakaleID == id).SingleOrDefault();
            if (makale == null)
            {
                return HttpNotFound();
            }

            return View(makale);
        }

        public ActionResult Hakkimda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult KategoriPartial()
        {
            return View(db.Kategoris.OrderByDescending(m=> m.Makales.Count).Take(5).ToList());
        }

        public JsonResult YorumYap(string yorum,int makaleid)
        {
            var uyeid = Session["uyeid"];
            if (yorum != null)
            {
                db.Yorums.Add(new Yorum {
                    UyeID = Convert.ToInt32(uyeid),
                    MakaleID = makaleid,
                    Icerik = yorum,
                    Tarih = DateTime.Now
                 });
                db.SaveChanges();
               
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult YorumSil(int id)
        {
            var uyeid = Session["uyeid"];
            var yorum = db.Yorums.Where(m => m.YorumID == id).SingleOrDefault();
            var makale = db.Makales.Where(m => m.MakaleID == yorum.MakaleID).SingleOrDefault();
            if (yorum.UyeID== Convert.ToInt32(uyeid) || Convert.ToInt32(Session["yetkiid"]) == 1)
            {
                db.Yorums.Remove(yorum);
                db.SaveChanges();
                return RedirectToAction("MakaleDetay", "Home", new { id = makale.MakaleID });
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult OkunmaArttir(int Makaleid)
        {
            var makale = db.Makales.Where(m => m.MakaleID == Makaleid).SingleOrDefault();
            makale.Okunma += 1;
            db.SaveChanges();
            return View();
        }
    }
}