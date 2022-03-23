using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class OtelOdasi
    {
        public int OdaNo { get; set; }
        public string TelefonNo { get; set; }
        public int KisiSayisi { get; set; }
        public string ManzaraBilgisi { get; set; }
        public string RezarvasyonDurumu { get; set; }
        public float Fiyat { get; set; }
    }
}
