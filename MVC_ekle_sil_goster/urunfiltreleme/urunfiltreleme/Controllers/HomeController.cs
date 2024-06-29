using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urunfiltreleme.Models;

namespace urunfiltreleme.Controllers
{
    public class HomeController : Controller
    {
        //tablo oluşturma kısmı
        Urun urn = new Urun();
        dbcontext tablolar = new dbcontext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult dortyuzdort()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }
        
        //Ürünleri ekleme işlemi
        [HttpPost]
        public ActionResult contact(string isim, string aciklama ,string urunkodu, int fiyat)
        {
            urn.isim = isim;
            urn.aciklama = aciklama;
            urn.fiyat = fiyat;
            urn.urunkodu = urunkodu;
            tablolar.urunler.Add(urn);
            tablolar.SaveChanges();

            return Redirect("/Home/contact");

        }

        public ActionResult faq()
        {
            return View();
        }

        public ActionResult feature()
        {
            return View();
        }

        //Bütün projeleri listeler
        public ActionResult project()
        {

            List<Urun> listem = tablolar.urunler.ToList();

            return View(listem);
        }

        //ürün fiyatına göre arama işlemi
        public ActionResult fiyatara(int min_deger, int max_deger)
        {

            List<Urun> listem = tablolar.urunler.Where(x => x.fiyat < max_deger && x.fiyat > min_deger).ToList();

            
            return View("project", listem);
        }

        //ürün ismine göre arama işlemi
        public ActionResult isimara(string aranan_urun)
        {
            // girilen harfler ile başlayan urunleri getir
            List<Urun> isimlistem = tablolar.urunler.Where(a => a.isim.StartsWith(aranan_urun)).ToList();

            return View("project", isimlistem);
        }


        //ürün koduna göre silme işlemi
        public ActionResult sil(string urunsil)
        {
            
            List<Urun> urunlistem = tablolar.urunler.Where(x => x.urunkodu == urunsil).ToList();
            tablolar.urunler.Remove(urunlistem[0]);
            tablolar.SaveChanges();

            return View("Index");
        }

        public ActionResult service()
        {
            return View();
        }

        public ActionResult team()
        {
            return View();
        }

        public ActionResult testimonial()
        {
            return View();
        }

    }
}