using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class LinkedListOtelOdasi:LinkedListADT
    {
        //BAĞLI LİSTE
        

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

        public int FindPosition(int odaNo)
        {
            int position = 0;
            Node temp = Head;

            if (((OtelOdasi)temp.Data).OdaNo == odaNo)
            {
                return position;
            }

            while (temp != null)
            {
                temp = temp.Next;
                position++;
                if (((OtelOdasi)temp.Data).OdaNo == odaNo)
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
    }
}
