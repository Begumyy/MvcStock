using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SATISLAR p)
        {
            db.SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}