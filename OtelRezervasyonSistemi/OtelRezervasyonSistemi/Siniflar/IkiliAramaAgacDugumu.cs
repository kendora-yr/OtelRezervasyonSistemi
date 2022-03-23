using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi
{
    public class IkiliAramaAgacDugumu
    {
        public Siniflar.Otel veri; // otel türünde oluşturulan veri nesnesi
        public IkiliAramaAgacDugumu sol;//ikili arama ağacının sol referansı
        public IkiliAramaAgacDugumu sag;//ikili arama ağacının sağ referansı

        public IkiliAramaAgacDugumu()//parent için oluşturulan kurucu metot
        {
        }

        public IkiliAramaAgacDugumu(Siniflar.Otel veri)//düğümler için oluşturulan kurucu metot
        {

            this.veri = veri;
            sol = null;
            sag = null;
        }
    }
}
