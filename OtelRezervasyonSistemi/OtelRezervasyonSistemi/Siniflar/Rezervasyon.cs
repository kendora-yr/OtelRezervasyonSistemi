using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
   public class Rezervasyon
   {
        public int RezervasyonNo { get; set; }
        public string OtelAd { get; set; }
        public int OdaNo { get; set; }
        public int KisiSayisi { get; set; }
        public int GunSayisi { get; set; }
        public float ToplamUcret { get; set; }
    }
}
