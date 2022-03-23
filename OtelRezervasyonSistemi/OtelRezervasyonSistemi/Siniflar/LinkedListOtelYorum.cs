using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    //baglı liste
    public class LinkedListOtelYorum: LinkedListADT
    {

       
        public override void DeleteFirst()
        {
            throw new NotImplementedException();
        }

        public override void DeleteLast()
        {
            throw new NotImplementedException();
        }

        public override void DeletePos(int position)
        {
            throw new NotImplementedException();
        }

        public string DisplayElements()
        {
            throw new NotImplementedException();
        }

        public override Node GetElement(int position)
        {
            throw new NotImplementedException();
        }

        public override void InsertFirst(object value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };

            if (Head == null)
                Head = tmpHead;
            else
            {
                //tmpHead'in next'i eski Head'i göstermeli
                tmpHead.Next = Head;
                //Yeni Head artık tmpHead oldu
                Head = tmpHead;
            }
            //Bağlı listedeki eleman sayısı bir arttı
            Size++;
        }

        public override void InsertLast(object value)
        {
            throw new NotImplementedException();
        }

        public override void InsertPos(int position, object value)
        {
            throw new NotImplementedException();
        }

        public bool VarMi(string eposta)
        {
            int kontrol = 0;
            Node temp = Head;
            while (temp != null)
            {
                if (((OtelYorum)temp.Data).YorumSahibiEposta == eposta)
                {
                    kontrol = 1;
                    break;
                }
                else
                {
                    temp = temp.Next;
                }

            }
            if (kontrol == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public float OtelPuaniHesapla()
        {
            Node temp = Head;
            float puan = 0;
            int sayac = 0;
            while (temp != null)
            {
                if (((OtelYorum)temp.Data).Puani != -1)
                {
                    puan += (float)((OtelYorum)temp.Data).Puani;
                    sayac++;
                    temp = temp.Next;
                }
                else
                {
                    temp = temp.Next; 
                }

            }
          
            return (puan / sayac);
            
            
        }

    }

}




