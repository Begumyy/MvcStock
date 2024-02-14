using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using MvcStock.Models.Entity;


namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var degerler = db.PRODUCTS.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<System.Web.Mvc.SelectListItem> degerler =(from i in db.CATEGORIES.ToList()
                                                           select new System.Web.Mvc.SelectListItem
                                                           {
                                                               Text =i.KATEGORIID.ToString()
                                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(PRODUCTS p1)
        {
            db.PRODUCTS.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}