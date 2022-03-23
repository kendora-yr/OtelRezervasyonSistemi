using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class HeapDugumu
    {
        public RezervasyonMusteri Deger { get; set; }
        public HeapDugumu(RezervasyonMusteri deger)
        {
            this.Deger = deger;
        }
    }
}
