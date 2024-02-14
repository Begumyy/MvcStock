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
    }
}