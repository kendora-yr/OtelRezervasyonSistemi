using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class Otel
    {
        public string Ad { get; set; }
        public string BulunduguIl { get; set; }
        public string BulunduguIlce { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Eposta { get; set; }
        public int YildizSayisi { get; set; }
        public int OdaSayisi { get; set; }
        public float Puani { get; set; }

        public LinkedListOtelPersonel personeller;
        public LinkedListOtelOdasi odalar;
        public LinkedListOtelYorum yorumlar;
        public Otel()
        {
            personeller = new LinkedListOtelPersonel();
            odalar = new LinkedListOtelOdasi();
            yorumlar = new LinkedListOtelYorum();
        }
    }
}
