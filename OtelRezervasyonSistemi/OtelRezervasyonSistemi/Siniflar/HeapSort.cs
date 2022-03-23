using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class HeapSort
    {
        public List<RezervasyonMusteri> RezervasyonMusteris { get; set; }
        RezervasyonMusteri musteri = new RezervasyonMusteri();
        public HeapSort(List<RezervasyonMusteri> rezervasyonMusteris)
        {
            RezervasyonMusteris = rezervasyonMusteris;
        }

        public object[] Sort()
        {
            Heap h = new Heap(RezervasyonMusteris.Count());
            object[] sorted = new object[RezervasyonMusteris.Count()];
            //Heap Ağacı Oluştur

            foreach (var item in RezervasyonMusteris)
                h.Insert(item);
            int i = 0;
            //Ağaçtaki maksimum elemanı al ve yeni diziye ekle
            while (!h.IsEmpty())
                sorted[i++] = h.RemoveMax().Deger.AdVeSoyad;
            return sorted;
        }
    }
}
