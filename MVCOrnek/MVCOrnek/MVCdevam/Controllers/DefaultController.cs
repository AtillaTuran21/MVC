using MVCdevam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCdevam.Controllers
{
    public class DefaultController : Controller

    {
        dbcon dbco = new dbcon();
        urun urn = new urun();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        /*
         * form oluştur forma multi part data ekle
         * input özelliğini file olarak belirle
         * action resultu veri karşılamak için httppostfilebase ile tanımla
         * gelen dosyanın ismini al
         * nereye kayıt edileceğini söyle
         * dosyayı kaydet
         */
        [HttpPost]
        public ActionResult resekle(string urunad, string aciklama, HttpPostedFileBase urunresim,string yazarad,int kitapfiyat,string urunkod)
        {

            //Dosya ismini al
            var dosyaisim = Path.GetFileName(urunresim.FileName);
            //
            var yol = Path.Combine(Server.MapPath("/resi"), dosyaisim);
            urunresim.SaveAs(yol);

            //Dosya ismini kaydetme 

            urn.ad = urunad;
            urn.aciklama = aciklama;
            urn.yazarad = yazarad;
            urn.urunkod = urunkod;
            urn.kitapfiyat = kitapfiyat;
            urn.urunresim = "/resi/" + dosyaisim;
            dbco.liste.Add(urn);
            dbco.SaveChanges();


            return View("goste");
        }

        public ActionResult reseklebos ()
        {
            return View();
        }

        public ActionResult goste()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sil(int Id)
        {
            var sil=dbco.liste.Where(x=>x.ID==Id).ToList();
            dbco.liste.Remove(sil[0]);
            dbco.SaveChanges();
            return View("Index");
        }
        public ActionResult books()
        {
            var yolu=dbco.liste.ToList();
            return View(yolu);
        }
        public ActionResult guncelle(int Id)
        {
            List<urun> ara = dbco.liste.Where(x=> x.ID ==Id).ToList();  
            

            return View("urunguncel",ara);
        }
        [HttpPost]
        public ActionResult urunguncel(int id, string urunad, string aciklama, string yazarad, int kitapfiyat, string urunkod,HttpPostedFileBase urunresim)
        {


            //Dosya ismini al
            var dosyaisim = Path.GetFileName(urunresim.FileName);
            //
            var yol = Path.Combine(Server.MapPath("/resi"), dosyaisim);
            urunresim.SaveAs(yol);

            //Dosya ismini kaydetme 

          var gunceldeger =   dbco.liste.Find(id);
            gunceldeger.ad = urunad;
          
            gunceldeger.aciklama = aciklama;
            gunceldeger.yazarad = yazarad;
            gunceldeger.urunkod = urunkod;
            gunceldeger.kitapfiyat = kitapfiyat;
            gunceldeger.urunresim = "/resi/" + dosyaisim;

            dbco.SaveChanges();


            return RedirectToAction("books");
        }

        public ActionResult blog()
        { return View(); }
        public ActionResult topseller()
        { return View(); }
        public ActionResult comingsoon() { return View(); }
        public ActionResult author() { return View(); }
        public ActionResult about()
        { return View(); }





    }
}