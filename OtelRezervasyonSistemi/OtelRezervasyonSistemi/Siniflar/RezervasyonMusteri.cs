using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class RezervasyonMusteri
    {
        public string TCKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdVeSoyad { get; set; }
        public string TelefonNo { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public int MusteriNo { get; set; }
    }
}
