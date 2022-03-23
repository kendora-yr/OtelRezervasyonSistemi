using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class HashMusteriler
    {
        int TABLE_SIZE = 200;
        HashChainEntry[] table;
        public HashMusteriler()
        {
            table = new HashChainEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }
        public void MusteriEkle(int MusteriNo, RezervasyonMusteri musteri)
        {
            int hash = (MusteriNo % TABLE_SIZE);
            if (table[hash] == null)
                table[hash] = new HashChainEntry(MusteriNo, musteri);

            else
            {
                HashChainEntry entry = table[hash];
                while (entry.Next != null && entry.Anahtar != MusteriNo)
                    entry = entry.Next;
                if (entry.Anahtar == MusteriNo)
                    entry.Deger = musteri;
                else
                    entry.Next = new HashChainEntry(MusteriNo, musteri);
            }
        }

        public RezervasyonMusteri MusteriGetir(int MusteriNo)
        {
            int hash = (MusteriNo % TABLE_SIZE);
            if (table[hash] == null)
                return null;
            else
            {
                HashChainEntry entry = table[hash];
                while (entry != null && entry.Anahtar != MusteriNo)
                    entry = entry.Next;
                if (entry == null)
                    return null;
                else
                    return (RezervasyonMusteri)entry.Deger;
            }
        }
        public void MusteriKaldir(int MusteriNo)
        {
            int hash = (MusteriNo % TABLE_SIZE);
            while (table[hash] != null && table[hash].Anahtar % TABLE_SIZE != MusteriNo % TABLE_SIZE)
            {
                hash = (hash + 1) % TABLE_SIZE;
            }
            HashChainEntry current = table[hash];
            bool isRemoved = false;
            while (current != null)
            {
                if (current.Anahtar == MusteriNo)
                {
                    table[hash] = current.Next;
                    isRemoved = true;
                    break;
                }
                if (current.Next != null)
                {
                    if (current.Next.Anahtar == MusteriNo)
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

    }
}
