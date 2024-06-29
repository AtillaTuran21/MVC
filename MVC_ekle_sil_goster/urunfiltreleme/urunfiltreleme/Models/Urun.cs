using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace urunfiltreleme.Models
{
    public class Urun
    {
        public int Id { get; set; }

        public int fiyat { get; set; }

        public string isim { get; set; }

        public string aciklama { get; set; }

        public string urunkodu { get; set; }

        public string urunresmi { get; set; }
    }
}