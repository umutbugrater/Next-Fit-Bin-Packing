using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BinPacking_NextFit
{
    class MyNextFit
    {
        int İlkAlan = 0;        // kutunun ilk kapladığı alanı tutar.
        int SonAlan = 0;       // kutuda yaptığımız işlemlerin en son ne kadarlık yer bıraktığını tutar.
        int KutuSayısı = 1;   // kaç tane kutu oluşturduğumuzu saymayı tutar.
        int i_kalan = 0;     // for döngüsünde her bir kutu içine giren , son paketin indexini tutar.
        int i_bas=0;        // for döngüsünde her bir kutu içine giren , ilk paketin indexini tutar.

        /// <summary>
        /// Paketleme işleminin yapıldığı ana fonksiyondur.
        /// </summary>
        /// <param name="PaketBoyutu_"> Herbir paketin boyutunu tutar. </param>
        /// <param name="PaketSayısı_"> Toplam paketin sayısını tutar. </param>
        /// <param name="KutununKaplayacağıYer_"> Kutunun toplam alanını veya kağladığı yeri tutar. </param>
        public void İslem(int[] PaketBoyutu_, int PaketSayısı_, int KutununKaplayacağıYer_)
        {
            İlkAlan = KutununKaplayacağıYer_;
            for (int i = 0; i < PaketSayısı_; i++)
            {
                if(KutununKaplayacağıYer_ >= PaketBoyutu_[i])
                {
                    KutununKaplayacağıYer_ -= PaketBoyutu_[i];
                    SonAlan = KutununKaplayacağıYer_;
                    i_kalan = i;
                }
                else
                {
                    if (PaketBoyutu_[i] > İlkAlan) 
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("GİRDİĞİNİZ "+PaketBoyutu_[i]+" BOYUTLU PAKET, BOYUTU KUTUNUN HACMİNDEN" +
                            " FAZLA OLDUĞU İÇİN BARINDIRILAMAZ.");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        for (int j = i_bas; j <= i_kalan;j++)
                        {
                            if (PaketBoyutu_[j]<İlkAlan)
                            {
                                Console.WriteLine(" {0}. kutuya giren elemanlar = {1}", KutuSayısı, PaketBoyutu_[j]);
                            }
                        }
                        i_bas = i_kalan + 1;
                        Console.WriteLine(" Sıradaki paket {0}. kutudan kalan alandan daha büyüktür. ", KutuSayısı);
                        Console.WriteLine(" {0}. kutudan kalan alan = {1}",KutuSayısı,SonAlan);
                        Console.WriteLine("************************************");Console.WriteLine(" {0}. bir yeni kutu oluşturuldu.", KutuSayısı + 1); 
                        KutununKaplayacağıYer_ = İlkAlan;
                        KutuSayısı++;
                        --i;
                    }
                }
            }
            for (int j = i_bas; j <= i_kalan; j++)
            {
                if (PaketBoyutu_[j] < İlkAlan)
                {
                    Console.WriteLine(" {0}. kutuya giren elemanlar = {1}", KutuSayısı, PaketBoyutu_[j]);
                }
            }
            Console.WriteLine(" {0}. kutudan kalan alan = {1}",KutuSayısı,SonAlan);
            Console.WriteLine("------------GENEL ÖZET---------------");
            Console.WriteLine(KutuSayısı+ " ADET KUTU OLUŞTURULDU.");
                
        }
        /// <summary>
        /// Tek başına kutunun alanından büyük olan paketlerin sayısının tutulduğu fonksiyondur
        /// </summary>
        /// <param name="PaketBoyutu_"> Herbir paketin boyutunu tutar. </param>
        /// <param name="PaketSayısı_"> Toplam paketin sayısını tutar. </param>
        /// <param name="KutununKaplayacağıYer_"> Kutunun toplam alanını veya kapladığı yeri tutar. </param>
        public void Bos(int[] PaketBoyutu_, int PaketSayısı_, int KutununKaplayacağıYer_)
        { 
            int DışarıdaKalanPaket = 0;
            for (int i = 0; i < PaketSayısı_; i++)
            {
                if (PaketBoyutu_[i] > KutununKaplayacağıYer_)
                {
                    DışarıdaKalanPaket++;
                }
            }
            Console.WriteLine(DışarıdaKalanPaket + " ADET KUTUYA GİRMEYEN PAKET VARDIR.");
        }
    }
}
