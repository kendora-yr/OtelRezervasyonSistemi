using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    class HashRezervasyonlar
    {
        int TABLE_SIZE = 200;
        HashChainEntry[] table;
        public HashRezervasyonlar()
        {
            table = new HashChainEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }
        public void RezervasyonEkle(int rezervasyonNo, Rezervasyon rezervasyon)
        {
            int hash = (rezervasyonNo % TABLE_SIZE);
            if (table[hash] == null)
                table[hash] = new HashChainEntry(rezervasyonNo, rezervasyon);

            else
            {
                HashChainEntry entry = table[hash];
                while (entry.Next != null && entry.Anahtar != rezervasyonNo)
                    entry = entry.Next;
                if (entry.Anahtar == rezervasyonNo)
                    entry.Deger = rezervasyon;
                else
                    entry.Next = new HashChainEntry(rezervasyonNo, rezervasyon);
            }
        }
        public Rezervasyon RezervasyonGetir(int rezervasyonNo)
        {
            int hash = (rezervasyonNo % TABLE_SIZE);
            if (table[hash] == null)
                return null;
            else
            {
                HashChainEntry entry = table[hash];
                while (entry != null && entry.Anahtar != rezervasyonNo)
                    entry = entry.Next;
                if (entry == null)
                    return null;
                else
                    return (Rezervasyon)entry.Deger;
            }
        }
        public void RezervasyonKaldir(int rezervasyonNo)
        {
            int hash = (rezervasyonNo % TABLE_SIZE);
            while (table[hash] != null && table[hash].Anahtar % TABLE_SIZE != rezervasyonNo % TABLE_SIZE)
            {
                hash = (hash + 1) % TABLE_SIZE;
            }
            HashChainEntry current = table[hash];
            bool isRemoved = false;
            while (current != null)
            {
                if (current.Anahtar == rezervasyonNo)
                {
                    table[hash] = current.Next;
                    isRemoved = true;
                    break;
                }
                if (current.Next != null)
                {
                    if (current.Next.Anahtar == rezervasyonNo)
                    {
                        HashChainEntry newNext = current.Next.Next;
                        current.Next = newNext;
                        isRemoved = true;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            if (!isRemoved)
            {
                System.Windows.Forms.MessageBox.Show("Silinecek bir şey bulunamadı");
                return;
            }

        }
        public List<Rezervasyon> musteriListesi()
        {
            List<Rezervasyon> musteri = new List<Rezervasyon>();
            for (int i = 0; i < TABLE_SIZE; i++)
            {
                HashChainEntry hashChainEntry = table[i];
                while (hashChainEntry != null)
                {
                    musteri.Add((Rezervasyon)hashChainEntry.Deger);
                    hashChainEntry = hashChainEntry.Next;
                }
            }
            return musteri;
        }
    }
}
