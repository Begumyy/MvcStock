using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var degerler = db.CATEGORIES.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult YeniKategori(CATEGORIES p1)
        {
            db.CATEGORIES.Add(p1);
            db.SaveChanges();
            return View();
        }

        //public ActionResult DELETE(int id)
        //{
        //    var kategori=db.CATEGORIES.Find(id);
        //    db.CATEGORIES.Remove(kategori);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public ActionResult DELETE(int id)
        {
            var kategori = db.CATEGORIES.Find(id);

            // Kategoriye bağlı ürünleri silebilir veya referanslarını null olarak ayarlayabilirsiniz
            var urunler = db.PRODUCTS.Where(p => p.URUNKATEGORI == id).ToList();
            foreach (var urun in urunler)
            {
                urun.URUNKATEGORI = null; // Ürünün kategori referansını null olarak ayarla
            }

            db.CATEGORIES.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}