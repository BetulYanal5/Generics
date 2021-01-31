using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sehirler = new List<string>();//List bir hazır classtır.
            sehirler.Add("İstanbul");
            Console.WriteLine(sehirler.Count);//Bu hazır classın hazır bir property(özelliği) olan Count kullanıldı 
            //Count dizinin eleman sayısını verir
            MyList<string> sehirler1 = new MyList<string>();//Burada ise kendi listemizi oluşturuyoruz
            sehirler1.Add("İstanbul");
            sehirler1.Add("İstanbul");
            sehirler1.Add("İstanbul");
            sehirler1.Add("İstanbul");
            Console.WriteLine(sehirler1.Count);

        }
    }
    class MyList<T>//Generic class  -  Burada T tiptir ve yukarıda tip olarak ne verirsem T onun karşılığı olur
    {
        T[] _array;
        T[] _tempArray;
        public MyList()//constructor
        {
            _array = new T[0];//MyList new dediğimiz de constructorda 0 elemanlı bir dizi oluşur
        }
        public void Add(T item)
        {
            _tempArray = _array;//temparray array'in referansını tutar yani artık aynı adresi tutuyorlar
            //Çünkü _array her new olduğunda adresi değişir ve içerisindeki elemanlar uçar, uçmaması için eski değerin adresini tutacak _tempArray dizisi oluşturuldu
            _array = new T[_array.Length + 1];//Yukarıda dizi 0 elemanlı tanımlandığından burada Add() metodu her çağrıldığında dizi elemanı bir arttırılır
            for (int i = 0; i < _tempArray.Length; i++)//_tempArray dizisindeki elemanları _array dizisine atar
            {
                _array[i] = _tempArray[i];
            }
            _array[_array.Length - 1] = item;
        }
        public int Count//Listeyi kendimiz oluşturduğumuz için Count'uda kendimiz oluşturmalıydık çünkü MyList hazır bir class değil bu nedenle Count da hazır gelmezdi.
        {
            get { return _array.Length; }
        }

    }
  
}
