using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class IkiliAramaAgaci
    {
      
        private IkiliAramaAgacDugumu kok;// ikili arama ağacı türünde oluşturulan kök
        private string dugumler;// düğümleri yazdırmak için string türünde oluşturulan düğümler
        public IkiliAramaAgaci()//parent düğümünün değerini tutmak için oluşturulan kurucu metot
        {
        }
        public IkiliAramaAgaci(IkiliAramaAgacDugumu kok)//düğümlerin değerini tutmak için oluşturulan kurucu metot
        {
            this.kok = kok;
        }
        
        public void InOrderDeneme(string il, string ilce, int yildizSayisi)
        {
            dugumler = "";
            InOrderIntDeneme(kok,il,ilce,yildizSayisi);
        }
        private void InOrderIntDeneme(IkiliAramaAgacDugumu dugum, string il, string ilce, int yildizSayisi)
        {
            if (dugum == null)
                return;
            InOrderIntDeneme(dugum.sol,il,ilce,yildizSayisi);
            ZiyaretDeneme(dugum,il,ilce, yildizSayisi);
            InOrderIntDeneme(dugum.sag,il,ilce, yildizSayisi);
        }
        private void ZiyaretDeneme(IkiliAramaAgacDugumu dugum, string il,string ilce, int yildizSayisi)
        {
            if (dugum.veri.BulunduguIl == il && dugum.veri.BulunduguIlce == ilce && dugum.veri.YildizSayisi == yildizSayisi)
            {
                dugumler += "Otel Adı:" + dugum.veri.Ad + "  İl:" + dugum.veri.BulunduguIl + "  İlçe:" + dugum.veri.BulunduguIlce + "  Adresi:" + dugum.veri.Adres + "  Telefonu:" + dugum.veri.TelefonNo + "  Eposta:" + dugum.veri.Eposta + "  Oda Sayısı:" + dugum.veri.OdaSayisi + "  Yıldız Sayısı:" + dugum.veri.YildizSayisi + "  Puanı:" + dugum.veri.Puani + "\n";                
            }
            
        }
        
        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DugumSayisi(IkiliAramaAgacDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                count = 1;
                count += DugumSayisi(dugum.sol);
                count += DugumSayisi(dugum.sag);
            }
            return count;
        }
        public int YaprakSayisi()
        {
            return YaprakSayisi(kok);
        }
        public int YaprakSayisi(IkiliAramaAgacDugumu dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                if ((dugum.sol == null) && (dugum.sag == null))
                    count = 1;
                else
                    count = count + YaprakSayisi(dugum.sol) + YaprakSayisi(dugum.sag);
            }
            return count;
        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }
        public void PreOrder()
        {
            dugumler = "";
            PreOrderInt(kok);
        }
        private void PreOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        public void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }
        private void InOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }
        private void Ziyaret(IkiliAramaAgacDugumu dugum)
        {
            dugumler += "Otel Adı:" + dugum.veri.Ad + " , ";
        }
        public void PostOrder()
        {
            dugumler = "";
            PostOrderInt(kok);
        }
        private void PostOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public void IsmeGoreOtelEkle(Otel eklenecekOtel)
        {
            IkiliAramaAgacDugumu tempParent = new IkiliAramaAgacDugumu();
            IkiliAramaAgacDugumu tempSearch = kok;
           
            while (tempSearch != null)
            {
                tempParent = tempSearch;
                if (eklenecekOtel.Ad==tempSearch.veri.Ad)
                {
                    System.Windows.Forms.MessageBox.Show("Otel Mevcut");
                    return;
                }
                else if(String.Compare(eklenecekOtel.Ad, tempSearch.veri.Ad)==-1)
                {
                    tempSearch = tempSearch.sol;
                }
                else
                {
                    tempSearch = tempSearch.sag;
                }
            }

            IkiliAramaAgacDugumu eklenecek = new IkiliAramaAgacDugumu(eklenecekOtel);
            if (kok == null)
            {
                kok = eklenecek;
            }
            else if (String.Compare(eklenecekOtel.Ad, tempParent.veri.Ad) == -1)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
            
        }

        public IkiliAramaAgacDugumu Ara(string otelAdi)
        {
            return AraInt(kok, otelAdi);
        }
        private IkiliAramaAgacDugumu AraInt(IkiliAramaAgacDugumu dugum,
                                            string OtelAdi)
        {
           
            if (dugum == null)
                return null;
            else if (dugum.veri.Ad == OtelAdi)
            {
                return dugum;
            }
            else if (String.Compare(dugum.veri.Ad, OtelAdi) == 1)
            {
                return (AraInt(dugum.sol, OtelAdi));
            }
            else
                return (AraInt(dugum.sag, OtelAdi));
        }

        public IkiliAramaAgacDugumu MinDeger()
        {
            IkiliAramaAgacDugumu tempSol = kok;
            while (tempSol.sol != null)
                tempSol = tempSol.sol;
            return tempSol;
        }

        public IkiliAramaAgacDugumu MaksDeger()
        {
            IkiliAramaAgacDugumu tempSag = kok;
            while (tempSag.sag != null)
                tempSag = tempSag.sag;
            return tempSag;
        }

        private IkiliAramaAgacDugumu Successor(IkiliAramaAgacDugumu silDugum)
        {
            IkiliAramaAgacDugumu successorParent = silDugum;
            IkiliAramaAgacDugumu successor = silDugum;
            IkiliAramaAgacDugumu current = silDugum.sag;
            while (current != null)
            {
                successorParent = current;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }

        public bool Sil(string deger)
        {
            if (kok != null)
            {

                IkiliAramaAgacDugumu current = kok;
                IkiliAramaAgacDugumu parent = kok;
                bool issol = true;
                Otel otel = (Otel)current.veri;
                //DÜĞÜMÜ BUL
                while (otel.Ad != deger)
                {
                    parent = current;
                    if (string.Compare(deger, otel.Ad) == -1)
                    {
                        issol = true;
                        current = current.sol;
                    }
                    else
                    {
                        issol = false;
                        current = current.sag;
                    }
                    if (current == null)
                        return false;
                    otel = (Otel)current.veri;
                }
                //DURUM 1: YAPRAK DÜĞÜM
                if (current.sol == null && current.sag == null)
                {
                    if (current == kok)
                        kok = null;
                    else if (issol)
                        parent.sol = null;
                    else
                        parent.sag = null;
                }
                //DURUM 2: TEK ÇOCUKLU DÜĞÜM
                else if (current.sag == null)
                {
                    if (current == kok)
                        kok = current.sol;
                    else if (issol)
                        parent.sol = current.sol;
                    else
                        parent.sag = current.sol;
                }
                else if (current.sol == null)
                {
                    if (current == kok)
                        kok = current.sag;
                    else if (issol)
                        parent.sol = current.sag;
                    else
                        parent.sag = current.sag;
                }
                //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
                else
                {
                    IkiliAramaAgacDugumu successor = Successor(current);
                    if (current == kok)
                        kok = successor;
                    else if (issol)
                        parent.sol = successor;
                    else
                        parent.sag = successor;
                    successor.sol = current.sol;
                }
                return true;
            }
            return false;


        }

        public int ElemanSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DerinlikHesapla(IkiliAramaAgacDugumu dugum)
        {
            int YukseklikSag = 0, YukseklikSol = 0;
            if (dugum != null)
            {
                YukseklikSag = DerinlikHesapla(dugum.sag);
                YukseklikSol = DerinlikHesapla(dugum.sol);
                if (YukseklikSag > YukseklikSol)
                {
                    return YukseklikSag + 1;
                }
                else
                {
                    return YukseklikSol + 1;
                }
            }
            else
            {
                return 0;
            }
        }
        public int AgacDerinlikSayisi()
        {
            return DerinlikHesapla(kok);
        }

        public void InOrderListeleme(string il, string ilce)
        {
            dugumler = "";
            InOrderIntListeleme(kok, il, ilce);
        }
        private void InOrderIntListeleme(IkiliAramaAgacDugumu dugum, string il, string ilce)
        {
            if (dugum == null)
                return;
            InOrderIntListeleme(dugum.sol, il, ilce);
            ZiyaretListeleme(dugum, il, ilce);
            InOrderIntListeleme(dugum.sag, il, ilce);
        }
        private void ZiyaretListeleme(IkiliAramaAgacDugumu dugum, string il, string ilce)
        {
            if (dugum.veri.BulunduguIl == il && dugum.veri.BulunduguIlce == ilce)
            {
                dugumler += "Otel Adı:" + dugum.veri.Ad + " " + "İl:" + dugum.veri.BulunduguIl + " " + "İlçe:" + dugum.veri.BulunduguIlce + " " + "Adresi:" + dugum.veri.Adres + " " + "Telefonu:" + dugum.veri.TelefonNo + " " + "Eposta:" + dugum.veri.Eposta + " " + "Oda Sayısı:" + dugum.veri.OdaSayisi + " " + "Yıldız Sayısı:" + dugum.veri.YildizSayisi + " " + "Puanı:" + dugum.veri.Puani + "\n";
            }


        }
    }
}
