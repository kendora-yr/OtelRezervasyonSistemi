using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    //bağlı liste
    public class LinkedListOtelPersonel : LinkedListADT
    {
        public override void DeleteFirst()
        {
            if (Head != null)
            {
                //Head'in next'i HeadNext'e atanıyor
                Node tempHeadNext = this.Head.Next;
                //HeadNext null ise zaten tek kayıt olan Head silinir.
                if (tempHeadNext == null)
                    Head = null;
                else
                    //HeadNext null değilse yeni Head, HeadNext olur.
                    Head = tempHeadNext;
                //Listedeki eleman sayısı bir azaltılıyor
                Size--;
            }
        }

        public override void DeleteLast()
        {
            throw new NotImplementedException();
        }

        public int FindPosition(string TC)
        {
            int position = 0;
            Node temp = Head;
            
            if (((OtelPersonel)temp.Data).TCKimlikNo == TC)
            {
                return position;
            }
        
            while (temp != null)
            {
                temp = temp.Next;
                position++;
                if (((OtelPersonel)temp.Data).TCKimlikNo == TC)
                {
                    return position;
                }

            }

            return -1;
        }

        public override void DeletePos(int position)
        {
            //öncesinde pos node'un next i pos node dan önceki dugumun next i olucak.
            //pos node bulunup NULL yapılacak
            Node posNode = Head;
            int i = 0;
            Node posPrevNode = null;
            if (Head == null)
                System.Windows.Forms.MessageBox.Show("Henüz kayıt eklenmemiş.");
            else if (position == 0)
            {
                DeleteFirst();
            }
            else
            {
                while (position != i)
                {
                    posPrevNode = posNode;
                    posNode = posNode.Next;
                    i++;

                }
                if (posPrevNode != null)
                    posPrevNode.Next = posNode.Next;
                else
                    Head = null;
                //posPrevNode.Next = posNode.Next;
                posNode = null;
                Size--;

            }

        }

        public string DisplayElements(string departman)
        {
            string temp = "";
            Node item = Head;
        
            temp += departman +" departmanına ait personeller:\n";
            while (item != null)
            {
                if (((OtelPersonel)item.Data).Departman == departman)
                {
                    temp += "Ad: " + ((OtelPersonel)item.Data).Ad + " Soyad: " + ((OtelPersonel)item.Data).Soyad + " TCNo: " + ((OtelPersonel)item.Data).TCKimlikNo + " Adres: " + ((OtelPersonel)item.Data).Adres + " Departman: " + ((OtelPersonel)item.Data).Departman + " Pozisyon: " + ((OtelPersonel)item.Data).Pozisyon + " E-Posta: " + ((OtelPersonel)item.Data).Eposta + "\n";
                    item = item.Next;
                }
                else
                {
                    item = item.Next;
                }
            }
            

            return temp;
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
            //Eski sonuncu node, Head'den başlanarak set ediliyor
            Node posNode = Head;
            int i = 0;

            if (position == 0)
            {
                InsertFirst(value);
            }
            else
            {
                //Yeni sonuncu node yaratılıyor
                Node newNode = new Node
                {
                    Data = value
                };

                Node tempNext = new Node();

                //Eski sonuncu node bulunuyor
                //Tail olsaydı sonuncuyu bulmaya gerek yoktu.
                while (position - 1 != i)
                {

                    posNode = posNode.Next;
                    i++;

                }

                //Eski sonuncu node referansı artık yeni sonuncu node'u gösteriyor
                tempNext = posNode.Next;
                posNode.Next = newNode;
                newNode.Next = tempNext;

                //Bağlı listedeki eleman sayısı bir arttı
                Size++;
            }
        }

        public bool VarMi(string TC)
        {
            int kontrol = 0;
            Node temp = Head;
            while (temp != null)
            {
                if (((OtelPersonel)temp.Data).TCKimlikNo == TC)
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
    }
}
