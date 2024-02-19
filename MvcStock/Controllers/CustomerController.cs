using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.CUSTOMERS select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.CUSTOMERS.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(CUSTOMERS p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.CUSTOMERS.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult DELETE (int id)
        {
            var musteri=db.CUSTOMERS.Find(id);
            db.CUSTOMERS.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.CUSTOMERS.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(CUSTOMERS p1)
        {
            var musteri=db.CUSTOMERS.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD= p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}