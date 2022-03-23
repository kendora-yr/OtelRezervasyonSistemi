using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi
{
    class OtelOdasi
    {
        //bağlı liste yapısında tutulacak
        public int OdaNo { get; set; }
        public string TelefonNo { get; set; }
        public int KisiSayisi { get; set; } //kaç kişilik
        public string ManzaraBilgisi { get; set; } //dağ,deniz vb.
        public string RezervasyonDurumu { get; set; } //(dolu/boş)
        public float Fiyat { get; set; }
    }
}
