using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.Siniflar
{
    public class Heap
    {
        private HeapDugumu[] heapArray;
        private int maxSize;
        private int currentSize;

        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            heapArray = new HeapDugumu[maxSize];
            currentSize = 0;

        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool Insert(RezervasyonMusteri value)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(value);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
          
            while (index > 0 && String.Compare((heapArray[parent].Deger).AdVeSoyad, (bottom.Deger).AdVeSoyad) == -1) 
            { 
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public HeapDugumu RemoveMax() // Remove maximum value HeapDugumu
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            heapArray[currentSize] = null;
            return root;
        }
        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                //Find larger child
               
                if (rightChild < currentSize && String.Compare((heapArray[leftChild].Deger).AdVeSoyad, (heapArray[rightChild].Deger).AdVeSoyad) ==-1)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
               
                if (String.Compare((heapArray[largerChild].Deger).AdVeSoyad, (top.Deger).AdVeSoyad) == -1 || (heapArray[largerChild].Deger).AdVeSoyad == (top.Deger).AdVeSoyad)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
       
    
        public List<RezervasyonMusteri> RezervasyonAl()
        {
            int sayac = 0;
            List<RezervasyonMusteri> RandevuAlanMusteriler = new List<RezervasyonMusteri>();
            while (heapArray[sayac] != null)
            {
                RandevuAlanMusteriler.Add(heapArray[sayac].Deger);
                sayac++;
            }
            return RandevuAlanMusteriler;
        }
       

         
    }
}
