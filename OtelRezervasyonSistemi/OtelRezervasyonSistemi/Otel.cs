using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi
{
    class Otel
    {
        public string Ad { get; set; }
        public string BulunduguIl { get; set; }
        public string BulunduguIlce { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Eposta { get; set; }
        public int YildizSayisi { get; set; }
        public int OdaSayisi { get; set; }
        public float Puani { get; set; } //Müşterilerin verdikleri puanların ortalaması
    }
}
