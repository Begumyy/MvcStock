using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                                                               Text=i.KATEGORIAD,
                                                               Value =i.KATEGORIID.ToString()
                                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(PRODUCTS p1)
        {
            //var ktg = db.CATEGORIES.Where(m=>m.KATEGORIID==p1.CATEGORIES.KATEGORIID).FirstOrDefault();
            //p1.CATEGORIES = ktg;
            //db.PRODUCTS.Add(p1);
            //db.SaveChanges();
            //return RedirectToAction("Index");



            //var ktg = db.PRODUCTS.Where(m => m.URUNID == p1.CATEGORIES.KATEGORIID).FirstOrDefault();



            ////var ktg = db.CATEGORIES.Where(m => m.KATEGORIID == p1.CATEGORIES.KATEGORIID).FirstOrDefault();

            //if (ktg.CATEGORIES != null)
            //{
            //    p1.CATEGORIES.KATEGORIID = ktg.CATEGORIES.KATEGORIID;
            //}


            //// Şimdi ktg değişkenini p1.CATEGORIES özelliğine atayın
            //p1.CATEGORIES.KATEGORIID = ktg.CATEGORIES.KATEGORIID; // Örneğin KATEGORIID özelliğini atayın (örneğin, bu özellik adı doğru değilse düzeltmelisiniz)
            //                                           // Diğer özellikleri de ihtiyaca göre aynı şekilde atayabilirsiniz

            //// Geri kalan kodlarınızı buraya ekleyin
            //db.PRODUCTS.Add(p1);
            //db.SaveChanges();
            //return RedirectToAction("Index");






            CATEGORIES category = p1.CATEGORIES; // Önce p1.CATEGORIES'i category adlı bir değişkene atayın

            if (category == null)
            {
                category = new CATEGORIES(); // category null ise yeni bir örnek oluşturun
            }

            var ktg = db.PRODUCTS.Where(m => m.URUNID == category.KATEGORIID).FirstOrDefault();

            // Şimdi category içindeki özellikleri kontrol ederek atamaları yapın
            if (category != null)
            {
                p1.CATEGORIES = category; // p1.CATEGORIES'e category'yi atayın
            }

            // Geri kalan kodlarınızı buraya ekleyin
            db.PRODUCTS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DELETE(int id)
        {
            
            var urun=db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.PRODUCTS.Find(id);

            List<System.Web.Mvc.SelectListItem> degerler = (from i in db.CATEGORIES.ToList()
                                                            select new System.Web.Mvc.SelectListItem
                                                            {
                                                                Text = i.KATEGORIAD,
                                                                Value = i.KATEGORIID.ToString()
                                                            }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir",urun);
        }

        public ActionResult Guncelle(PRODUCTS p)
        {
            var urun = db.PRODUCTS.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA=p.MARKA;
            urun.STOK=p.STOK;
            urun.FIYAT=p.FIYAT;
            //urun.URUNKATEGORI=p.URUNKATEGORI;
            CATEGORIES category = p.CATEGORIES;
            var ktg = db.PRODUCTS.Where(m => m.URUNID == category.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.CATEGORIES.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}