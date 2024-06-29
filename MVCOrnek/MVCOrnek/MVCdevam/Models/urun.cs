using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCdevam.Models
{
    public class urun
    {
        public int ID { get; set; }
        public string ad {  get; set; }
        public string yazarad { get; set; }
        public string aciklama {  get; set; }
        public string urunresim {  get; set; }
        public int kitapfiyat { get; set; }
        public string urunkod { get; set; }
    }
}