using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi
{
    class OtelYorum
    {
        //bağlı liste yapısında tutulacak
        public string YorumSahibiAd { get; set; }
        public string YorumSahibiSoyad { get; set; }
        public string YorumSahibiEposta { get; set; }
        public string Yorumu { get; set; }
        public int Puani { get; set; }
    }

}
